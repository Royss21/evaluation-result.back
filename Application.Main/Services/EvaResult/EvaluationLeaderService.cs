
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.Config.EvaluationLeader;
    using Application.Dto.Employee.Area;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Common.Enums;
    using Domain.Main.Employee;
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
            var areas = new List<AreaDto>();
            var evaluationComponents = await _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(ec => ec.EvaluationId.Equals(request.EvaluationId))
                    .ToListAsync();
            
            if (!evaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies) 
                && request.TypeImportLeaders == TypeImportLeadersEnum.Competencies)
                throw new WarningException($"El componente de COMPETENCIAS no esta configurado para la evaluación.");

            if (!evaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives) 
                && request.TypeImportLeaders == TypeImportLeadersEnum.AreaObjectives)
                throw new WarningException($"El componente de OBJETIVOS DE AREA no esta configurado para la evaluación.");


            var evaluationLeaderFileDataDto = GetDataFromImportedFile(request.File, request.TypeImportLeaders);

            if (request.TypeImportLeaders == TypeImportLeadersEnum.AreaObjectives)
                areas = await _unitOfWorkApp.Repository.AreaRepository
                        .Find(f => evaluationLeaderFileDataDto.Select(s => (int)s.AreaId).Contains(f.Id))
                        .ProjectTo<AreaDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

            var evaluationComponent = request.TypeImportLeaders == TypeImportLeadersEnum.Competencies
                                        ? evaluationComponents.First(ec => ec.ComponentId == GeneralConstants.Component.Competencies)
                                        : evaluationComponents.First(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives);

            if (request.IsToReprocess)
                await DeletePreviousImport(request.EvaluationId, evaluationComponent.Id);

            await ValidateData(evaluationLeaderFileDataDto, request.TypeImportLeaders, areas);

            var evaluationCollaborators = await GetDataForImport(evaluationLeaderFileDataDto, request.TypeImportLeaders, request.EvaluationId);
            var dniLeaders = evaluationLeaderFileDataDto.Select(s => s.DniLeader).Distinct().ToList();
            var evaluationLeadersExiting = !request.IsToReprocess
                                                ? await _unitOfWorkApp.Repository.EvaluationLeaderRepository
                                                            .Find(elr => elr.EvaluationId.Equals(request.EvaluationId) && elr.EvaluationComponentId == evaluationComponent.Id)
                                                            .ProjectTo<EvaluationLeaderExistingDto>(_mapper.ConfigurationProvider)
                                                            .ToListAsync()
                                                : new List<EvaluationLeaderExistingDto>();

            var evaluationLeaders = new List<EvaluationLeader>();
            var leaderStages = new List<LeaderStage>();
            var leaderCollaborators = new List<LeaderCollaborator>();

            if (request.TypeImportLeaders == TypeImportLeadersEnum.Competencies)
                dniLeaders.ForEach(dniLeader =>
                {

                    var evaluationCollaborator = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(dniLeader));
                    var evaluationLeaderExists = evaluationLeadersExiting.FirstOrDefault(f => 
                        f.EvaluationCollaboratorId.Equals(evaluationCollaborator.Id) &&
                        f.EvaluationComponentId == evaluationComponent.Id
                    );

                    //NUEVOS LIDERES
                    if(evaluationLeaderExists is null)
                    {
                        var stagesLeader = evaluationLeaderFileDataDto
                                    .Where(w => w.DniLeader.Equals(dniLeader))
                                    .Select(s => s.StageId)
                                    .Distinct()
                                    .Select(id => new LeaderStage { StageId = (int)id })
                                    .ToList();

                        stagesLeader.ForEach(sl =>
                        {
                            sl.LeaderCollaborators = evaluationLeaderFileDataDto
                                .Where(elf =>
                                        elf.StageId == sl.StageId &&
                                        elf.DniLeader.Equals(dniLeader)
                                ).Select(s => new LeaderCollaborator
                                {
                                    EvaluationCollaboratorId = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(s.DniCollaborator)).Id
                                }).ToList();
                        });

                        evaluationLeaders.Add(new EvaluationLeader
                        {
                            EvaluationCollaboratorId = evaluationCollaborator.Id,
                            EvaluationComponentId = evaluationComponent.Id,
                            EvaluationId = request.EvaluationId,
                            LeaderStages = stagesLeader
                        });
                    }
                    //LIDERES QUE YA EXISTEN 
                    else
                    {
                        var stagesLeaderExisting = evaluationLeaderExists?.LeaderStagesExistingDto?.Select(ls => ls.StageId) ?? new List<int>();

                        evaluationLeaderExists?.LeaderStagesExistingDto.ForEach(leaderStage =>
                        {
                            leaderCollaborators = evaluationLeaderFileDataDto
                                .Where(elf =>
                                        elf.StageId == leaderStage.StageId &&
                                        elf.DniLeader.Equals(dniLeader)
                                ).Select(ls => new LeaderCollaborator
                                {
                                    LeaderStageId = leaderStage.Id,
                                    EvaluationCollaboratorId = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(ls.DniCollaborator)).Id
                                }).ToList();
                        });

                        var stagesLeaderNews = evaluationLeaderFileDataDto
                                    .Where(w => 
                                        w.DniLeader.Equals(dniLeader) &&
                                        !stagesLeaderExisting.Contains((int)w.StageId)
                                    )
                                    .Select(s => s.StageId)
                                    .Distinct()
                                    .Select(id => new LeaderStage { StageId = (int)id })
                                    .ToList();

                        if(stagesLeaderNews.Any())
                            stagesLeaderNews.ForEach(sl =>
                            {
                                sl.EvaluationLeaderId = evaluationLeaderExists.Id;
                                sl.LeaderCollaborators = evaluationLeaderFileDataDto
                                    .Where(elf =>
                                            elf.StageId == sl.StageId &&
                                            elf.DniLeader.Equals(dniLeader)
                                    ).Select(s => new LeaderCollaborator
                                    {
                                        EvaluationCollaboratorId = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(s.DniCollaborator)).Id
                                    }).ToList();
                            });
                    }
                });
            else
            {
                dniLeaders.ForEach(dniLeader =>
                {
                    var evaluationCollaborator = evaluationCollaborators.First(f => f.Collaborator.DocumentNumber.Equals(dniLeader));
                    var evaluationLeaderExists = evaluationLeadersExiting.Where(f =>
                        f.EvaluationCollaboratorId.Equals(evaluationCollaborator.Id) &&
                        f.EvaluationComponentId == evaluationComponent.Id
                    ).ToList();

                    var areasImport = evaluationLeaderFileDataDto
                        .Where(el => el.DniLeader.Equals(dniLeader))
                        .Select(s => s.AreaId)
                        .Distinct()
                        .Select(areaId => areas.First(a => a.Id == areaId).Name)
                        .ToList();

                    var areasNews = areasImport.Where(areaName => !evaluationLeaderExists.Select(el => el.AreaName).Contains(areaName))
                        .ToList();

                    evaluationLeaders = areasNews.Select(areaName => new EvaluationLeader
                    {
                        AreaName = areaName,
                        EvaluationCollaboratorId = evaluationCollaborator.Id,
                        EvaluationComponentId = evaluationComponent.Id,
                        EvaluationId = request.EvaluationId
                    }).ToList();
                });
            }

            await _unitOfWorkApp.Repository.EvaluationLeaderRepository.AddRangeAsync(evaluationLeaders);
            if (leaderStages.Any()) await _unitOfWorkApp.Repository.LeaderStageRepository.AddRangeAsync(leaderStages);
            if (leaderCollaborators.Any()) await _unitOfWorkApp.Repository.LeaderCollaboratorRepository.AddRangeAsync(leaderCollaborators);

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<PaginationResultDto<EvaluationLeaderDto>> GetAllPagingAsync(EvaluationLeaderFilterDto filter)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<EvaluationLeaderDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<EvaluationLeader, EvaluationLeaderDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add =>
                            //add.EvaluationCollaborators.Any(ec => ec.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim())) ||
                            add.EvaluationCollaborator.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.EvaluationCollaborator.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.EvaluationCollaborator.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.AreaName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                        );
            }

            var paging = await _unitOfWorkApp.Repository.EvaluationLeaderRepository.FindAllPagingAsync(parametersDomain);
            var evaluationLeaders = await paging.Entities.ProjectTo<EvaluationLeaderDto>(_mapper.ConfigurationProvider).ToListAsync();

            evaluationLeaders.ForEach(async el =>
            {
                if(!el.AreaName.Equals(""))
                    el.CountAssignedCollaborator = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.CountAsync(c => c.AreaName.Equals(el.AreaName));
                else
                    el.CountAssignedCollaborator = await _unitOfWorkApp.Repository.LeaderCollaboratorRepository.CountAsync(lc => el.StagesId.Contains(lc.LeaderStageId));
            });

            return new PaginationResultDto<EvaluationLeaderDto>
            {
                Count = paging.Count,
                Entities = evaluationLeaders
            };
        }

        public async Task<bool> ExistsPreviousImportAsync(int componentId)
        {
            return await _unitOfWorkApp.Repository.EvaluationLeaderRepository
                .Find(f => f.EvaluationComponent.ComponentId == componentId)
                .AnyAsync();
        }

        public async Task<(IEnumerable<LeaderCollaboratorsDto>, int)> GetAllCollaboratorByLeaderAsync(int evaluationLeaderId, LeaderCollaboratorsFilterDto filter)
        {
            var predicate = PredicateBuilder.New<EvaluationCollaborator>();

            if (filter.ComponentId == GeneralConstants.Component.AreaObjectives)
            {
                var leader = await _unitOfWorkApp.Repository.EvaluationLeaderRepository
                        .Find(f => f.Id == evaluationLeaderId)
                        .ToListAsync();

                predicate = PredicateBuilder.New<EvaluationCollaborator>(ec =>
                            leader.Select(s => s.AreaName.ToLower().Trim()).Contains(ec.AreaName.ToLower().Trim()) &&
                            (
                                ec.AreaName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                                ec.Collaborator.DocumentNumber.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                                ec.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                                ec.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                                ec.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                            ));
            }
            else if (filter.ComponentId == GeneralConstants.Component.Competencies)
                 predicate = PredicateBuilder.New<EvaluationCollaborator>(ec =>
                            ec.LeaderCollaborators.Any(a => a.LeaderStage.EvaluationLeaderId == evaluationLeaderId) &&
                            (
                                ec.Collaborator.DocumentNumber.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                                ec.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                                ec.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                                ec.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                            ));

            var countCollaborators = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(predicate)
                    .CountAsync();

            var leaderCollaborators = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(predicate)
                    .Skip(filter.PageIndex)
                    .Take(filter.PageSize)
                    .ProjectTo<LeaderCollaboratorsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return (leaderCollaborators, countCollaborators);
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
                        AreaId = row["Id Area"] == DBNull.Value ? 0 : Convert.ToInt32(row["Dni Lider"]),
                        DniLeader = row["Dni Lider"] == DBNull.Value ? "" : row["Dni Lider"].ToString(),
                        LeaderName = row["Nombre Lider"] == DBNull.Value ? "" : row["Nombre Lider"].ToString(),
                    }).ToList();                   
            }
        }
        private async Task ValidateData(List<EvaluationLeaderFileDataDto> evaluationLeaderFileDataDto, TypeImportLeadersEnum typeImportLeaders, List<AreaDto> areas)
        {

            if (evaluationLeaderFileDataDto.Any(el => string.IsNullOrWhiteSpace(el.DniLeader)))
                throw new WarningException("El archivo contiene algunos DNI DE LIDERES vacios");

            if (typeImportLeaders == TypeImportLeadersEnum.Competencies)
            {
                var stages = await _unitOfWorkApp.Repository.StageRepository.Find(s => s.Id != GeneralConstants.StagesIds.Approval).ToListAsync();

                if (evaluationLeaderFileDataDto.Any(el => !stages.Select(e => e.Id).Contains(el.StageId ?? 0)))
                    throw new WarningException("El archivo contiene algunos IDS DE LAS ETAPAS vacias o no coinciden con algun ID DE ETAPA DEL SISTEMA");

                if (evaluationLeaderFileDataDto.Any(el => string.IsNullOrWhiteSpace(el.DniCollaborator)))
                    throw new WarningException("El archivo contiene algunos DNI DE COLABORADORES estan vacios");
            }
            else
            {
                var areasIdImport = evaluationLeaderFileDataDto.Select(el => el.AreaId).Distinct().ToList();

                if(areasIdImport.Any(areaId => !areas.Select(a => a.Id).Contains((int)areaId)))
                    throw new WarningException("El archivo contiene algunos IDS DE AREAS vacios o no coinciden con algún ID DE AREA DEL SISTEMA");
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

            var evaluation = await _unitOfWorkApp.Repository.EvaluationRepository.Find(e => e.Id.Equals(evaluationId)).FirstAsync();
            var dateFilter = evaluation.CreateDate.AddMonths(GeneralConstants.MonthsToSubtract);
            var collaborators = await _unitOfWorkApp.Repository.CollaboratorRepository
                    .Find(c => dnis.Contains(c.DocumentNumber) && c.DateAdmission < dateFilter)
                    .ToListAsync();

            if (!collaborators.Any())
                throw new WarningException("No se ha encontrado colaboradores activos");

            var dniCollaboratorsActive = collaborators.Select(c => c.DocumentNumber).ToList();
            if (dnis.Any(dni => !dniCollaboratorsActive.Contains(dni)))
            {
                dnisNotFound = dnis.Where(dni => !dniCollaboratorsActive.Contains(dni)).ToList();

                throw new WarningException($"Los COLABORADORES con los siguientes DNIS no aplican a la evaluación: {string.Join(", ", dnisNotFound)}");
            }    

            var evaluationCollaborators = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(ec => ec.EvaluationId.Equals(evaluationId))
                    .ToListAsync();

            if (!evaluationCollaborators.Any())
                throw new WarningException("No se ha encontrado colaboradores registrados en la evaluacion");
           
            var collaboratorIds = collaborators.Select(c => c.Id).ToList();
            var evaluationCollaboratorIds = evaluationCollaborators.Select(c => c.CollaboratorId).ToList();

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
