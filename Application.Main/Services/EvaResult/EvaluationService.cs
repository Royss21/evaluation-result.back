
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.PrimeNg;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.Employee;
    using Domain.Main.EvaResult;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EvaluationService : BaseService, IEvaluationService
    {
        private readonly IEvaluationComponentService _evaluationComponentService;
        public EvaluationService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<EvaluationDto> CreateAsync(EvaluationCreateDto request)
        {
            if (!request.EvaluationComponentsDto.Any())
                throw new WarningException("No hay ningun componente seleccionado para la evaluacion.");

            if (request.EvaluationComponentsDto.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies) && !request.ComponentStagesDto.Any())
                throw new WarningException("No seleccionado las etapas del componente de COMPETENCIAS");

            var evaluation = _mapper.Map<Evaluation>(request);
            if(!request.IsEvaluationTest)
            {
                var countEvaluations = await CountEvaluationsCurrentPeriod();
                var countEvaluationsConfig = await CountEvaluationByPeriodConfig();

                if (countEvaluations == countEvaluationsConfig)
                    throw new WarningException($"Llegó al limite de {countEvaluationsConfig} evaluaciones por periodo");
            }

            var currentDate = DateTime.UtcNow.GetDatePeru();
            evaluation.StatusId = request.IsEvaluationTest
                ? GeneralConstants.StatusGenerals.Test
                : currentDate.RangeDateBetween(evaluation.StartDate, evaluation.EndDate)
                    ? GeneralConstants.StatusGenerals.InProgress
                    : GeneralConstants.StatusGenerals.Create;

            await _unitOfWorkApp.Repository.EvaluationRepository.AddAsync(evaluation);

            var collaborators = await GetCollaboratorApplyToFilter();

            var evaluationComponents = _mapper.Map<List<EvaluationComponent>>(request.EvaluationComponentsDto);
            evaluationComponents.ForEach(ec => ec.EvaluationId = evaluation.Id);
            await _unitOfWorkApp.Repository.EvaluationComponentRepository.AddRangeAsync(evaluationComponents);

            var componentCompetencies = evaluationComponents.FirstOrDefault(ec => ec.ComponentId == GeneralConstants.Component.Competencies);
            
            if(componentCompetencies is not null)
            {
                var componentStages = _mapper.Map<List<ComponentStage>>(request.ComponentStagesDto);
                componentStages.ForEach(cs => cs.EvaluationComponentId = componentCompetencies.Id);
                await _unitOfWorkApp.Repository.ComponentStageRepository.AddRangeAsync(componentStages);
            }

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<EvaluationDto>(evaluation);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EvaluationDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResultDto<EvaluationDto>> GetAllPagingAsync(PrimeTable primeTable)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluationDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        #region Helpers Functions

        private async Task<int> CountEvaluationsCurrentPeriod()
        {
            var currentDate = DateTime.UtcNow.GetDatePeru();

            return await _unitOfWorkApp.Repository.EvaluationRepository
                .CountAsync(e => currentDate >= e.StartDate && currentDate <= e.EndDate);
        }

        private async Task<int> CountEvaluationByPeriodConfig()
        {
            var configuration = await _unitOfWorkApp.Repository.LabelDetailRepository
                .Find(e => e.LabelId == GeneralConstants.CountEvaluationAnnualConfigId)
                .FirstOrDefaultAsync();

            if (configuration is null)
                throw new WarningException("No se ha encontrado recurso de configuraion");

            return (int)configuration.RealValue;
        }

        private async Task<List<Collaborator>> GetCollaboratorApplyToFilter()
        {
            return await _unitOfWorkApp.Repository.CollaboratorRepository.Find(c =>
                c.DateAdmission < DateTime.UtcNow.GetDatePeru().AddMonths(-3)
            ).ToListAsync();
        }
        #endregion

    }
}
