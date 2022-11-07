
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;
    using System.Threading.Tasks;

    public class ComponentCollaboratorService : BaseService, IComponentCollaboratorService
    {
        public ComponentCollaboratorService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> EvaluateAsync(ComponentCollaboratorEvaluateDto request)
        {
            var isStatusCompleted = false;
            var componentCollaborator = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => f.Id.Equals(request.ComponentCollaboratorId), false)
                    .FirstAsync();
            //var componentCollaboratorConducts = new List<ComponentCollaboratorConduct>();

            if (componentCollaborator is null)
                throw new WarningException("El componente a evaluar del colaborador no se ha encontrado");

            var componentCollaboratorDetails = await _unitOfWorkApp.Repository.ComponentCollaboratorDetailRepository
                    .Find(f => request.ComponentCollaboratorDetailsEvaluateDto.Select(s => s.ComponentCollaboratorDetailId).Contains(f.Id), false)
                    .ToListAsync();

            if (!componentCollaboratorDetails.Any())
                throw new WarningException("Los objetivos/competencias del colaborador no se han encontrado");

            //if(request.ComponentId == GeneralConstants.Component.Competencies)
            //{
            //    componentCollaboratorConducts = await _unitOfWorkApp.Repository.ComponentCollaboratorConductRepository
            //            .Find(f => componentCollaboratorDetails.Select(s => s.Id).Contains(f.ComponentCollaboratorDetailId))
            //            .ToListAsync();

            //    if (!componentCollaboratorConducts.Any())
            //        throw new WarningException("Las conductas del colaborador no se han encontrado");
            //}

            switch (request.ComponentId)
            {
                case GeneralConstants.Component.CorporateObjectives:

                    isStatusCompleted = componentCollaborator.StatusId == GeneralConstants.StatusGenerals.Completed;

                    componentCollaboratorDetails.ForEach(ccd =>
                    {
                        var valueResult = request.ComponentCollaboratorDetailsEvaluateDto
                            .First(f=> f.ComponentCollaboratorDetailId == ccd.Id).ValueResult;
                        //var formulaQuerySql = 
                        
                        ccd.Result = valueResult;
                        ccd.Compliance = 0;
                    });

                    break;
                case GeneralConstants.Component.AreaObjectives:
                    break;
                case GeneralConstants.Component.Competencies:
                    break;
                default:
                    break;
            }

            return true;
        }

        #region Helper Functions

        private async Task<decimal> CalculateFormulaCompliance(string formulaQuerySql)
        {
            return (await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .RunSqlQuery<decimal>("[dbo].[uspCalculateFormulaCompliance]", new { formulaQuerySql }))
                    .FirstOrDefault();
        }

        #endregion
    }
}
