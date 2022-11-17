
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.Period;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Services.EvaResult.Interfaces;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Validators;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;

    public class PeriodService : BaseService, IPeriodService
    {
        public PeriodService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<PeriodDto> CreateAsync(PeriodCreateDto periodDto)
        {
            var period = _mapper.Map<Period>(periodDto);

            var resultValidator = await _unitOfWorkApp.Repository.PeriodRepository.AddAsync(
                period, new PeriodCreateValidator(_unitOfWorkApp.Repository.PeriodRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<PeriodDto>(period);
        }

        public async Task<bool> UpdateAsync(PeriodUpdateDto periodDto)
        {
            var period = _mapper.Map<Period>(periodDto);

            var resultValidator = await _unitOfWorkApp.Repository.PeriodRepository.UpdateAsync(
                period, new PeriodCreateValidator(_unitOfWorkApp.Repository.PeriodRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var period = await _unitOfWorkApp.Repository.PeriodRepository.GetAsync(id);

            if (period is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.PeriodRepository.DeleteAsync(period);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PeriodDto>> GetAllAsync()
        {
            var periods = await _unitOfWorkApp.Repository.PeriodRepository
                    .All()
                    .ProjectTo<PeriodDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return periods;
        }

        public async Task<PaginationResultDto<PeriodDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<PeriodDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Period, PeriodDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.StartDate.ToString().ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.EndDate.ToString().ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.PeriodRepository.FindAllPagingAsync(parametersDomain);
            var periods = await paging.Entities.ProjectTo<PeriodDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<PeriodDto>
            {
                Count = paging.Count,
                Entities = periods
            };
        }

        public async Task<PeriodDto> GetByIdAsync(int id)
        {
            var period = await _unitOfWorkApp.Repository.PeriodRepository
                   .Find(c => c.Id == id)
                   .ProjectTo<PeriodDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();

            if (period is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            return period;
        }

        
    }
}
