namespace Application.Main.Services.Security
{
    using Application.Dto.Pagination;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Security.Interfaces;
    using Domain.Main.Security;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LogService : BaseService, ILogService
    {
        public LogService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> CreateAsync(LogEntity request)
        {
            await _unitOfWorkApp.Repository.LogRepository.AddAsync(request);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<LogEntity>> GetAllAsync()
        {
            var logs = await _unitOfWorkApp.Repository.LogRepository
                    .All()
                    .ToListAsync();

            return logs;
        }

        public async Task<PaginationResultDto<LogEntity>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<LogEntity>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<LogEntity, LogEntity>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => 
                                            add.Message.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.FullNameService.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.InnerExceptionMessage.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.StackTrace.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.TypeException.ToLower().Contains(primeTable.GlobalFilter.ToLower())
                                     );
            }

            var paging = await _unitOfWorkApp.Repository.LogRepository.FindAllPagingAsync(parametersDomain);

            return new PaginationResultDto<LogEntity>
            {
                Count = paging.Count,
                Entities = paging.Entities
            };
        }
    }
}
