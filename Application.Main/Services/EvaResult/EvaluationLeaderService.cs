
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Common.Enums;
    using Domain.Main.EvaResult;
    using ExcelDataReader;
    using Microsoft.AspNetCore.Http;
    using System.Data;
    using System.Threading.Tasks;

    public class EvaluationLeaderService : BaseService, IEvaluationLeaderService
    {
        public EvaluationLeaderService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> ImportBulkAsync(EvaluationLeaderFileDto request)
        {
            var evaluationComponents = await _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(ec => ec.EvaluationId.Equals(request.EvaluationId))
                    .ToListAsync();

            if (!evaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies) && request.TypeImportLeaders == TypeImportLeadersEnum.Competencies)
                throw new WarningException($"El componente de COMPETENCIAS no esta configurado para la evaluación.");

            if (!evaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives) && request.TypeImportLeaders == TypeImportLeadersEnum.AreaObjectives)
                throw new WarningException($"El componente de OBJETIVOS DE AREA no esta configurado para la evaluación.");

            var evaluationLeaderFileDataDto = GetDataFromImportedFile(request.File, request.TypeImportLeaders);
            var evaluationComponent = request.TypeImportLeaders == TypeImportLeadersEnum.Competencies
                                        ? evaluationComponents.First(ec => ec.ComponentId == GeneralConstants.Component.Competencies)
                                        : evaluationComponents.First(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives);

            if (request.IsToReprocess)
                await DeletePreviousImport(request.EvaluationId, evaluationComponent.Id);

            await ValidateData(evaluationLeaderFileDataDto, request.TypeImportLeaders);

            var evaluationCollaborators = await GetDataForImport(evaluationLeaderFileDataDto, request.TypeImportLeaders, request.EvaluationId);
            var dniLeaders = evaluationLeaderFileDataDto.Select(s => s.DniLeader).Distinct().ToList();
            var evaluationLeadersExiting = !request.IsToReprocess
                                                ? await _unitOfWorkApp.Repository.EvaluationLeaderRepository
                                                            .Find(elr => elr.EvaluationId.Equals(request.EvaluationId) && elr.EvaluationComponentId == evaluationComponent.Id)
                                                            .ProjectTo<EvaluationLeaderExistingDto>(_mapper.ConfigurationProvider)
                                                            .ToListAsync()
                                                : new List<EvaluationLeaderExistingDto>();

            var dniLeadersExisting = evaluationLeadersExiting.Select(ele => ele.DocumentNumber).Distinct();
            var evaluationLeaders = new List<EvaluationLeader>();

            if (request.TypeImportLeaders == TypeImportLeadersEnum.Competencies)
            {
                evaluationLeaders = dniLeaders.Where(dniLeader => !dniLeadersExisting.Contains(dniLeader))
                    .Select(dniLeader =>
                    {
                        var evaluationCollaborator = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(dniLeader));
                        var evaluationLeaderExists = evaluationLeadersExiting.FirstOrDefault(f => f.EvaluationCollaboratorId.Equals(evaluationCollaborator.Id));

                        var stagesLeader = evaluationLeaderFileDataDto
                                .Where(w => w.DniLeader.Equals(dniLeader) && 
                                    (!evaluationLeaderExists?.LeaderStagesExistingDto?.Select(ls => ls.StageId)?.Contains((int)w.StageId) ?? true)
                                )
                                .Select(s => s.StageId)
                                .Distinct()
                                .Select(id => new LeaderStage {  StageId = (int)id })
                                .ToList();

                        stagesLeader.ForEach(sl =>
                        {
                            var evaluationCollaboratorIdsExisting = evaluationLeaderExists?.LeaderStagesExistingDto?
                                        .FirstOrDefault(f => f.StageId == sl.StageId)?.LeaderCollaboratorsExistingDto
                                        .Select(lc => lc.EvaluationCollaboratorId);

                            sl.LeaderCollaborators = evaluationLeaderFileDataDto
                                .Where(elf =>
                                        elf.StageId == sl.StageId &&
                                        elf.DniLeader.Equals(dniLeader) &&
                                        (!evaluationCollaboratorIdsExisting?.Contains(evaluationCollaborators.First(ec => ec.Collaborator.DocumentNumber.Equals(elf.DniCollaborator)).Id) ?? true)
                                ).Select(s => new LeaderCollaborator
                                {
                                    EvaluationCollaboratorId = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(s.DniCollaborator)).Id
                                }).ToList();
                        });

                        return new EvaluationLeader
                        {
                            EvaluationCollaboratorId = evaluationCollaborator.Id,
                            EvaluationComponentId = evaluationComponent.Id,
                            EvaluationId = request.EvaluationId,
                            LeaderStages = stagesLeader
                        };
                    }).ToList();
            }
            else
            {
                evaluationLeaders = dniLeaders.Where(dniLeader => !dniLeadersExisting.Contains(dniLeader))
                    .Select(dniLeader =>
                    {
                        var evalationCollaborator = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(dniLeader));

                        return new EvaluationLeader
                        {
                            AreaId= evalationCollaborator.AreaId,
                            EvaluationCollaboratorId = evalationCollaborator.Id,
                            EvaluationComponentId = evaluationComponent.Id,
                            EvaluationId = request.EvaluationId
                        };
                    }).ToList();
            }

            await _unitOfWorkApp.Repository.EvaluationLeaderRepository.AddRangeAsync(evaluationLeaders);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }


        #region Helper Functions

        private List<EvaluationLeaderFileDataDto> GetDataFromImportedFile(IFormFile file, TypeImportLeadersEnum typeImportLeaders)
        {
            if (file is null)
                throw new WarningException("No ha adjuntado el archivo .XLSX para importar");

            using var fileStream = file.OpenReadStream();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = file.OpenReadStream())
            {
                var dataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var dataSet = dataReader.AsDataSet(ConfigurarDataReader());
                var hojaImportarLideres = dataSet.Tables[0];

                if(!hojaImportarLideres.AsEnumerable().Any())
                    throw new WarningException("No se ha encontrado informacion para importar");

                if (typeImportLeaders == TypeImportLeadersEnum.Competencies)
                    return hojaImportarLideres.AsEnumerable().Select(row => new EvaluationLeaderFileDataDto
                    {
                        StageId = row["Id Etapa"] == DBNull.Value ? 0 : Convert.ToInt32(row?["Id Etapa"]),
                        StageName = row["Nombre Etapa"] == DBNull.Value ? "" : row["Nombre Etapa"].ToString(),
                        DniLeader = row["Dni Lider"] == DBNull.Value ? "" : row["Dni Lider"].ToString(),
                        LeaderName = row["Nombre Lider"] == DBNull.Value ? "" : row["Nombre Lider"].ToString(),
                        DniCollaborator = row["Dni Colaborador"] == DBNull.Value ? "" : row["Dni Colaborador"].ToString(),
                        CollaboratorName = row["Nombre Colaborador"] == DBNull.Value ? "" : row["Nombre Colaborador"].ToString(),
                    }).ToList();
                else
                    return hojaImportarLideres.AsEnumerable().Select(row => new EvaluationLeaderFileDataDto
                    {
                        DniLeader = row["Dni Lider"] == DBNull.Value ? "" : row["Dni Lider"].ToString(),
                        LeaderName = row["Nombre Lider"] == DBNull.Value ? "" : row["Nombre Lider"].ToString(),
                    }).ToList();                   
            }
        }
        private async Task ValidateData(List<EvaluationLeaderFileDataDto> evaluationLeaderFileDataDto, TypeImportLeadersEnum typeImportLeaders)
        {
            var evaluationLeadersData = evaluationLeaderFileDataDto;
            var stages = await _unitOfWorkApp.Repository.StageRepository.Find(s => s.Id != GeneralConstants.Stages.Approval).ToListAsync();

            if (evaluationLeadersData.Any(el => string.IsNullOrWhiteSpace(el.DniLeader)))
                throw new WarningException("El archivo contiene algunos DNI DE LIDERES vacios");

            if (typeImportLeaders == TypeImportLeadersEnum.Competencies)
            {
                if (evaluationLeadersData.Any(el => !stages.Select(e => e.Id).Contains(el.StageId ?? 0)))
                    throw new WarningException("El archivo contiene algunos IDS DE LAS ETAPAS vacias o no coinciden con algun ID DE ETAPA EXISTENTE");

                if (evaluationLeadersData.Any(el => string.IsNullOrWhiteSpace(el.DniCollaborator)))
                    throw new WarningException("El archivo contiene algunos DNI DE COLABORADORES estan vacios");
            }
        }
        private async Task<List<EvaluationCollaborator>> GetDataForImport(List<EvaluationLeaderFileDataDto> evaluationLeaderFileDataDto, 
                                                                        TypeImportLeadersEnum typeImportLeaders, 
                                                                        Guid evaluationId)
        {
            var dnisNotFound = new List<string>();
            var dnis = new List<string>();

            if (typeImportLeaders == TypeImportLeadersEnum.Competencies)
                dnis.AddRange(evaluationLeaderFileDataDto.Select(elfd => elfd.DniCollaborator).ToList());

            dnis.AddRange(evaluationLeaderFileDataDto.Select(elfd => elfd.DniLeader).ToList());
            dnis = dnis.Distinct().ToList();

            var dateCreationEvaluation = await _unitOfWorkApp.Repository.EvaluationRepository.Find(e => e.Id.Equals(evaluationId)).FirstAsync();
            var dateFilter = dateCreationEvaluation.CreateDate.AddMonths(GeneralConstants.MonthsToSubtract);
            var collaborators = await _unitOfWorkApp.Repository.CollaboratorRepository
                    .Find(c => dnis.Contains(c.DocumentNumber) && c.DateAdmission < dateFilter)
                    .ToListAsync();

            if (!collaborators.Any())
                throw new WarningException("No se ha encontrado colaboradores activos");

            var dniCollaboratorsActive = collaborators.Select(c => c.DocumentNumber).ToList();
            if (dnis.Any(dni => !dniCollaboratorsActive.Contains(dni)))
            {
                dnisNotFound = dnis.Where(dni => !dniCollaboratorsActive.Contains(dni)).ToList();

                throw new WarningException($"Los COLABORADORES con los siguientes DNIS no se han encontrado: {string.Join(", ", dnisNotFound)}");
            }    

            var evaluationCollaborators = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(ec => ec.EvaluationId.Equals(evaluationId))
                    .ToListAsync();

            var collaboratorIds = collaborators.Select(c => c.Id).ToList();
            var evaluationCollaboratorIds = evaluationCollaborators.Select(c => c.CollaboratorId).ToList();

            if (!evaluationCollaborators.Any())
                throw new WarningException("No se ha encontrado colaboradores registrados en la evaluacion");

            if (collaboratorIds.Any(idcoll => !evaluationCollaboratorIds.Contains(idcoll)))
            {
                var idsNotFound = collaboratorIds.Where(id => !evaluationCollaboratorIds.Contains(id))
                                                .ToList();

                throw new WarningException($"Los siguientes COLABORADORES con DNIS no se encuentran registrados en la EVALUACION {string.Join(",", collaborators.Where(c => idsNotFound.Contains(c.Id)).Select(s => s.DocumentNumber))}");
            }

            evaluationCollaborators = evaluationCollaborators.Where(ec => collaboratorIds.Contains(ec.CollaboratorId)).ToList();
            evaluationCollaborators.ForEach(ec => ec.Collaborator = collaborators.First(c => c.Id == ec.CollaboratorId));

            return evaluationCollaborators;
        }
        private async Task DeletePreviousImport(Guid evaluationId, int evaluationComponentId)
        {
            var removeEvaluationLeaders = await _unitOfWorkApp.Repository.EvaluationLeaderRepository
                    .Find(f => f.EvaluationComponentId == evaluationComponentId && f.EvaluationId.Equals(evaluationId))
                    .Include("LeaderStages.LeaderCollaborators")
                    .ToListAsync();
      
            _unitOfWorkApp.Repository.EvaluationLeaderRepository.RemoveRange(removeEvaluationLeaders);
        }

        #endregion
    }
}
