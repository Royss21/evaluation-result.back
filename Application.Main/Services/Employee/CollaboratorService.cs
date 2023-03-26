namespace Application.Main.Services.Employee
{
    using Domain.Main.Employee;
    using Application.Dto.Pagination;
    using Application.Main.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Dto.Employee.Collaborator;
    using Application.Main.Services.Employee.Interfaces;
    using Application.Main.Services.Employee.Validators;
    using Domain.Common.Constants;
    using Application.Main.Services.EvaResult.Interfaces;

    public class CollaboratorService : BaseService, ICollaboratorService
    {
        private readonly IEvaluationCollaboratorService _service;

        public CollaboratorService(IEvaluationCollaboratorService service,  IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _service = service;
        }

        public async Task<CollaboratorDto> CreateAsync(CollaboratorCreateDto request)
        {
            var collaborator = _mapper.Map<Collaborator>(request);
            var resultValidator = await _unitOfWorkApp.Repository.CollaboratorRepository
                .AddAsync(collaborator, new CollaboratorCreateUpdateValidation(_unitOfWorkApp.Repository.CollaboratorRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<CollaboratorDto>(collaborator);

        }

        public async Task<bool> UpdateAsync(CollaboratorUpdateDto request)
        {
            var collaborator = _mapper.Map<Collaborator>(request);
            var resultValidator = await _unitOfWorkApp.Repository.CollaboratorRepository
                .UpdateAsync(collaborator, new CollaboratorCreateUpdateValidation(_unitOfWorkApp.Repository.CollaboratorRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CollaboratorNotInEvaluationDto>> GetAllCollaboratorNotInEvaluationAsync(Guid evaluationId)
        {
            var collaboratorIdsInEvaluation = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(f => f.EvaluationId.Equals(evaluationId))
                    .Select(s => s.CollaboratorId)
                    .ToListAsync();

            return await _unitOfWorkApp.Repository.CollaboratorRepository
                    .Find(f => !collaboratorIdsInEvaluation.Contains(f.Id))
                    .ProjectTo<CollaboratorNotInEvaluationDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<PaginationResultDto<CollaboratorDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<CollaboratorDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Collaborator, CollaboratorDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.MiddleName.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.LastName.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.DocumentNumber.Contains(primeTable.GlobalFilter));
            }

            var paging = await _unitOfWorkApp.Repository.CollaboratorRepository.FindAllPagingAsync(parametersDomain);
            var collaborators = await paging.Entities.ProjectTo<CollaboratorDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<CollaboratorDto>
            {
                Count = paging.Count,
                Entities = collaborators
            };

        }

        public async Task<bool> ValidateSubscribeEvaluationCurrent(Guid colaboratorId)
        {
            var currentDate = DateTime.UtcNow.GetDateTimePeru();

            return await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(f => f.CollaboratorId.Equals(colaboratorId) && (currentDate >= f.Evaluation.StartDate && currentDate <= f.Evaluation.EndDate))
                    .AnyAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var currentDate = DateTime.UtcNow.GetDateTimePeru();
            var collaborator = await _unitOfWorkApp.Repository.CollaboratorRepository.GetAsync(id);

            if (collaborator is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.CollaboratorRepository.DeleteAsync(collaborator);

            var evaluationCollaboratorId = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(f => f.CollaboratorId.Equals(id) && (currentDate >= f.Evaluation.StartDate && currentDate <= f.Evaluation.EndDate))
                    .Select(s => s.Id)
                    .FirstAsync();


            await _unitOfWorkApp.SaveChangesAsync();

            await _service.DeleteAsync(evaluationCollaboratorId);

            return true;
        }
    }
}
