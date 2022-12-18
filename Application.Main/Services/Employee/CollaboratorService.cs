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

    public class CollaboratorService : BaseService, ICollaboratorService
    {
        public CollaboratorService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<CollaboratorNotInEvaluationDto> CreateAsync(CollaboratorNotInEvaluationCreateDto request)
        {
            var collaborator = _mapper.Map<Collaborator>(request);
            var resultValidator = await _unitOfWorkApp.Repository.CollaboratorRepository
                .AddAsync(collaborator, new CollaboratorNotInEvaluationCreateUpdateValidation(_unitOfWorkApp.Repository.CollaboratorRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<CollaboratorNotInEvaluationDto>(collaborator);

        }

        public async Task<bool> UpdateAsync(CollaboratorUpdateDto request)
        {
            var collaborator = _mapper.Map<Collaborator>(request);
            var resultValidator = await _unitOfWorkApp.Repository.CollaboratorRepository
                .UpdateAsync(collaborator, new CollaboratorNotInEvaluationCreateUpdateValidation(_unitOfWorkApp.Repository.CollaboratorRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

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

        public async Task<PaginationResultDto<CollaboratorNotInEvaluationDto>> GetAllPagingCollaboratorNotInEvaluationAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<CollaboratorNotInEvaluationDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Collaborator, CollaboratorNotInEvaluationDto>(_mapper);

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
            var collaborators = await paging.Entities.ProjectTo<CollaboratorNotInEvaluationDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<CollaboratorNotInEvaluationDto>
            {
                Count = paging.Count,
                Entities = collaborators
            };
        }

    }
}
