namespace Application.Main.Services.Employee
{
    using Domain.Main.Employee;
    using Domain.Common.Constants;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Dto.Employee.Area;
    using Application.Main.Service.Base;
    using Application.Main.Services.Employee.Interfaces;
    using Application.Main.Services.Employee.Validators;

    public class AreaService : BaseService, IAreaService
    {
        public AreaService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<AreaDto> CreateAsync(AreaCreateDto request)
        {
            var area = _mapper.Map<Area>(request);

            var resultValidator = await _unitOfWorkApp.Repository.AreaRepository
                .AddAsync(area, new AreaCreateValidator(_unitOfWorkApp.Repository.AreaRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<AreaDto>(area);
        }

        public async Task<bool> UpdateAsync(AreaUpdateDto request)
        {
            var area = _mapper.Map<Area>(request);
            var resultValidator = await _unitOfWorkApp.Repository.AreaRepository
                    .UpdateAsync(area, new AreaCreateValidator(_unitOfWorkApp.Repository.AreaRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var area = await _unitOfWorkApp.Repository.AreaRepository.GetAsync(id);

            if (area is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.AreaRepository.DeleteAsync(area);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<AreaDto>> GetAllAsync()
        {
            var area = await _unitOfWorkApp.Repository.AreaRepository
                    .All()
                    .ProjectTo<AreaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return area;
        }

        public async Task<AreaDto> GetByIdAsync(int id)
        {
            var area = await _unitOfWorkApp.Repository.AreaRepository
                    .Find(c => c.Id == id)
                    .ProjectTo<AreaDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (area is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            return area;
        }

        public async Task<IEnumerable<AreaDto>> GetByIdGerency(int id)
        {
            var area = await _unitOfWorkApp.Repository.AreaRepository
                    .Find(x => x.GerencyId == id)
                    .ProjectTo<AreaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return area;
        }

        public async Task<PaginationResultDto<AreaDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<AreaDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Area, AreaDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paging = await _unitOfWorkApp.Repository.AreaRepository.FindAllPagingAsync(parametersDomain);
            var areas = await paging.Entities.ProjectTo<AreaDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<AreaDto>
            {
                Count = paging.Count,
                Entities = areas
            };
        }
    }
}
