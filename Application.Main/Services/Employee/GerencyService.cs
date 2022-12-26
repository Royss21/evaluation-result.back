namespace Application.Main.Services.Employee
{
    using Domain.Main.Employee;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Application.Dto.Pagination;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Dto.Employee.Gerency;
    using Application.Main.Services.Employee.Interfaces;

    public class GerencyService : BaseService, IGerencyService
    {
        public GerencyService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<IEnumerable<GerencyDto>> GetAllAsync()
        {
            var gerencies = await _unitOfWorkApp.Repository.GerencyRepository
                    .All()
                    .ProjectTo<GerencyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return gerencies;
        }

        public async Task<PaginationResultDto<GerencyDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<GerencyDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Gerency, GerencyDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.GerencyRepository.FindAllPagingAsync(parametersDomain);
            var gerencies = await paging.Entities.ProjectTo<GerencyDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<GerencyDto>
            {
                Count = paging.Count,
                Entities = gerencies
            };
        }
    }
}
