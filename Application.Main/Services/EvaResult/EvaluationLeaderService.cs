
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Common.Enums;
    using System.Threading.Tasks;

    public class EvaluationLeaderService : BaseService, IEvaluationLeaderService
    {
        public EvaluationLeaderService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> ImportBulkAsync(EvaluationLeaderFileDto request)
        {

            var evaluationComponents = _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(ec => ec.EvaluationId.Equals(request.EvaluationId));

            if (!evaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies) && request.TypeImportLeaders == TypeImportLeadersEnum.Competencies)
                throw new WarningException($"El componente de COMPETENCIAS no esta configurado para la evaluación.");

            if (!evaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives) && request.TypeImportLeaders == TypeImportLeadersEnum.AreaObjectives)
                throw new WarningException($"El componente de OBJETIVOS DE AREA no esta configurado para la evaluación.");

            var evaluationComponent = request.TypeImportLeaders == TypeImportLeadersEnum.Competencies
                                        ? evaluationComponents.First(ec => ec.ComponentId == GeneralConstants.Component.Competencies)
                                        : evaluationComponents.First(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives);

            //REMOVER INFROMACION EXISTENTE

            await ValidateData(request);

            return true;
        }


        #region Helper Functions

        private async Task ValidateData(EvaluationLeaderFileDto request)
        {
            var evaluationLeadersData = request.EvaluationLeaderFileDataDto;
            var stages = await _unitOfWorkApp.Repository.StageRepository.All().ToListAsync();

            if (evaluationLeadersData.Any(el => string.IsNullOrWhiteSpace(el.DniLeader)))
                throw new WarningException("El archivo contiene algunos DNI DE LIDERES estan vacios");

            if (request.TypeImportLeaders == TypeImportLeadersEnum.Competencies)
            {
                if (!evaluationLeadersData.Any(el => stages.Select(e => e.Id).ToList().Contains(el.StageId ?? 0)))
                    throw new WarningException("El archivo contiene algunos ID DE LAS ETAPAS estan vacias o no coinciden con alguna etapa");

                if (evaluationLeadersData.Any(el => string.IsNullOrWhiteSpace(el.DniCollaborator)))
                    throw new WarningException("El archivo contiene algunos DNI DE COLABORADORES estan vacios");
            }
        }

        #endregion
    }
}
