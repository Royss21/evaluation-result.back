namespace Application.Main.Services.Security
{
    using Application.Dto.Pagination;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Security.Interfaces;
    using Domain.Main.Security;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AuditService : BaseService, IAuditService
    {
        public AuditService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<IEnumerable<AuditEntity>> GetAllAsync()
        {
            var audits = await _unitOfWorkApp.Repository.AuditRepository
                   .All()
                   .ToListAsync();

            return audits;
        }

        public async Task<PaginationResultDto<AuditEntity>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<AuditEntity>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<AuditEntity, AuditEntity>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add =>
                                            add.TableName.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.KeyValues.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.OldValues.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.NewValues.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                                            add.Action.ToLower().Contains(primeTable.GlobalFilter.ToLower())
                                     );
            }

            var paging = await _unitOfWorkApp.Repository.AuditRepository.FindAllPagingAsync(parametersDomain);

            return new PaginationResultDto<AuditEntity>
            {
                Count = paging.Count,
                Entities = paging.Entities
            };
        }
    }
}
