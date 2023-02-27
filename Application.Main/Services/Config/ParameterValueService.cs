
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.ParameterValue;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Application.Main.Services.Config.Validators;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class ParameterValueService : BaseService, IParameterValueService
    {
        public ParameterValueService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<ParameterValueDto> CreateAsync(ParameterValueCreateDto request)
        {
            var parameterValue = _mapper.Map<ParameterValue>(request);
            var resultValidator = await _unitOfWorkApp.Repository.ParameterValueRepository
                    .AddAsync(parameterValue, new ParameterValueCreateUpdateValidator(_unitOfWorkApp.Repository.ParameterValueRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<ParameterValueDto>(parameterValue);
        }

        public async Task<bool> UpdateAsync(ParameterValueUpdateDto request)
        {
            var parameterValue = _mapper.Map<ParameterValue>(request);

            var resultValidator = await _unitOfWorkApp.Repository.ParameterValueRepository
                   .UpdateAsync(parameterValue, new ParameterValueCreateUpdateValidator(_unitOfWorkApp.Repository.ParameterValueRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parameterValue = await _unitOfWorkApp.Repository.ParameterValueRepository.GetAsync(id);

            if (parameterValue is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.ParameterValueRepository.DeleteAsync(parameterValue);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<PaginationResultDto<ParameterValueDto>> GetAllPagingAsync(ParameterValueFilterDto filter)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<ParameterValueDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<ParameterValue, ParameterValueDto>(_mapper);
            parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.ParameterRangeId.Equals(filter.ParameterRangeId));

            var paging = await _unitOfWorkApp.Repository.ParameterValueRepository.FindAllPagingAsync(parametersDomain);
            var parametersValue = await paging.Entities.ProjectTo<ParameterValueDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<ParameterValueDto>
            {
                Count = paging.Count,
                Entities = parametersValue
            };
        }

        public async Task<List<ParameterValueDto>> GetAllByParameterRangeAsync(Guid parameterRangeId)
        {
            var parametersValue = await _unitOfWorkApp.Repository.ParameterValueRepository
                   .Find(c => c.ParameterRangeId.Equals(parameterRangeId))
                   .ProjectTo<ParameterValueDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();

            return parametersValue;
        }
    }
}
