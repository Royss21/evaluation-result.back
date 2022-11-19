
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.Level;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Application.Main.Services.Config.Validators;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class LevelService : BaseService, ILevelService
    {
        public LevelService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<LevelDto> CreateAsync(LevelCreateDto request)
        {
            var level = _mapper.Map<Level>(request);
            var resultValidator = await _unitOfWorkApp.Repository.LevelRepository
                    .AddAsync(level, new LevelCreateUpdateValidator(_unitOfWorkApp.Repository.LevelRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<LevelDto>(level);
        }

        public async Task<bool> UpdateAsync(LevelUpdateDto request)
        {
            var level = _mapper.Map<Level>(request);
            var resultValidator = await _unitOfWorkApp.Repository.LevelRepository
                    .UpdateAsync(level, new LevelCreateUpdateValidator(_unitOfWorkApp.Repository.LevelRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var level = await _unitOfWorkApp.Repository.LevelRepository.GetAsync(id);

            if (level is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.LevelRepository.DeleteAsync(level);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<LevelDto>> GetAllAsync()
        {
            var levels = await _unitOfWorkApp.Repository.LevelRepository
                    .All()
                    .ProjectTo<LevelDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return levels;
        }

        public async Task<PaginationResultDto<LevelDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<LevelDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Level, LevelDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.Description.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.LevelRepository.FindAllPagingAsync(parametersDomain);
            var levels = await paging.Entities.ProjectTo<LevelDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<LevelDto>
            {
                Count = paging.Count,
                Entities = levels
            };
        }

        public async Task<LevelDto> GetByIdAsync(int id)
        {
            var Level = await _unitOfWorkApp.Repository.LevelRepository
                   .Find(c => c.Id == id)
                   .ProjectTo<LevelDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();

            if (Level is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            return Level;
        }

        public async Task<LevelDependencyDto> HasDependencyOtherEntitiesAsync(int id)
        {
            return await _unitOfWorkApp.Repository.LevelRepository
                    .Find(f => f.Id == id)
                    .ProjectTo<LevelDependencyDto>(_mapper.ConfigurationProvider)
                    .FirstAsync();
        }
    }
}
