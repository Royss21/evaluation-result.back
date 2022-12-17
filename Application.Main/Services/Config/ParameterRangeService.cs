
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.ParameterRange;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Application.Main.Services.Config.Validators;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class ParameterRangeService : BaseService, IParameterRangeService
    {
        public ParameterRangeService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<ParameterRangeDto> CreateAsync(ParameterRangeCreateDto request)
        {
            var parameterRange = _mapper.Map<ParameterRange>(request);
            parameterRange.IsInternalConfiguration = false;

            var resultValidator = await _unitOfWorkApp.Repository.ParameterRangeRepository
                    .AddAsync(parameterRange, new ParameterRangeCreateUpdateValidator(_unitOfWorkApp.Repository.ParameterRangeRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<ParameterRangeDto>(parameterRange);
        }

        public async Task<bool> UpdateAsync(ParameterRangeUpdateDto request)
        {
            var parameterRange = _mapper.Map<ParameterRange>(request);
            var resultValidator = await _unitOfWorkApp.Repository.ParameterRangeRepository
                     .UpdateAsync(parameterRange, new ParameterRangeCreateUpdateValidator(_unitOfWorkApp.Repository.ParameterRangeRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var parameterRange = await _unitOfWorkApp.Repository.ParameterRangeRepository
                    .Find(f => f.Id.Equals(id))
                    .Include("ParametersValue")
                    .FirstOrDefaultAsync();

            if (parameterRange is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.ParameterRangeRepository.DeleteAsync(parameterRange);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<PaginationResultDto<ParameterRangeDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<ParameterRangeDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<ParameterRange, ParameterRangeDto>(_mapper);

            parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(a => !a.IsInternalConfiguration);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.Description.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.ParameterRangeRepository.FindAllPagingAsync(parametersDomain);
            var parametersRange = await paging.Entities.ProjectTo<ParameterRangeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<ParameterRangeDto>
            {
                Count = paging.Count,
                Entities = parametersRange
            };
        }

        public async Task<ParameterRangeDto> GetByIdAsync(Guid id)
        {
            var parameterRange = await _unitOfWorkApp.Repository.ParameterRangeRepository
                   .Find(c => c.Id.Equals(id))
                   .ProjectTo<ParameterRangeDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();

            if (parameterRange is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            return parameterRange;
        }

        public async Task<IEnumerable<ParameterRangeWithValuesDto>> GetAllWithValuesAsync()
        {
            var levels = await _unitOfWorkApp.Repository.ParameterRangeRepository
                    .All()
                    .ProjectTo<ParameterRangeWithValuesDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return levels;
        }
    }
}
