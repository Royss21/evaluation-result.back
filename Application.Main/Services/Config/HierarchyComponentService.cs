
namespace Application.Main.Services.Config
{
    using Application.Dto.Config.HierarchyComponent;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Config.Interfaces;
    using Application.Main.Services.Config.Validators;
    using Domain.Common.Constants;
    using Domain.Main.Config;

    public class HierarchyComponentService : BaseService, IHierarchyComponentService
    {
        public HierarchyComponentService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> CreateBulkAsync(List<HierarchyComponentCreateDto> request)
        {
            HierarchyComponentValidator.ValidateComponents(_mapper.Map<List<BaseHierarchyComponentDto>>(request));

            var hierarchyComponents = _mapper.Map<List<HierarchyComponent>>(request);

            await _unitOfWorkApp.Repository.HierarchyComponentRepository.AddRangeAsync(hierarchyComponents);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateBulkAsync(List<HierarchyComponentUpdateDto> request)
        {
            HierarchyComponentValidator.ValidateComponents(_mapper.Map<List<BaseHierarchyComponentDto>>(request));

            var hierarchyComponents = _mapper.Map<List<HierarchyComponent>>(request);

            _unitOfWorkApp.Repository.HierarchyComponentRepository.UpdateRange(hierarchyComponents);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByHierarchyAsync(int hiearchyId)
        {
            var hierarchyComponents = await _unitOfWorkApp.Repository.HierarchyComponentRepository
                    .Find(f => f.HierarchyId == hiearchyId, false)
                    .ToListAsync();

            if (!hierarchyComponents.Any())
                throw new WarningException(Messages.General.ResourceNotFound);

            _unitOfWorkApp.Repository.HierarchyComponentRepository.RemoveRange(hierarchyComponents);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<PaginationResultDto<HierarchyComponentPagingDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<HierarchyComponentPagingDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<HierarchyComponent, HierarchyComponentPagingDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Hierarchy.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()))
                        .AddCondition(add => add.Weight.ToString().ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.HierarchyComponentRepository.FindAllPagingAsync(parametersDomain);
            var hierarchyComponents = await paging.Entities.ProjectTo<HierarchyComponentDto>(_mapper.ConfigurationProvider).ToListAsync();

            var hierarchyPaging = hierarchyComponents.Select(s => new { s.HierarchyId, s.HierarchyName }).Distinct().Select(hierarchy => new HierarchyComponentPagingDto
            {
                HierarchyId = hierarchy.HierarchyId,
                HierarchyName = hierarchy.HierarchyName,
                Components = hierarchyComponents.Where(w => w.HierarchyName.ToLower().Equals(hierarchy.HierarchyName.ToLower()))
                    .Select(x => new HierarchyOnlyComponent(x.ComponentId, x.ComponentName, x.Weight)).ToList()
            }).ToList();

            return new PaginationResultDto<HierarchyComponentPagingDto>
            {
                Count = hierarchyPaging.Count(),
                Entities = hierarchyPaging
            };
        }

        //public async Task<PaginationResultDto<HierarchyComponentPagingDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        //{
        //    var parametersDto = PrimeNgToPaginationParametersDto<HierarchyComponentPagingDto>.Convert(primeTable);
        //    var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<HierarchyComponent, HierarchyComponentPagingDto>(_mapper);

        //    if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
        //    {
        //        parametersDomain.FilterWhere = parametersDomain.FilterWhere
        //                .AddCondition(add => add.Hierarchy.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()))
        //                .AddCondition(add => add.Weight.ToString().ToLower().Contains(primeTable.GlobalFilter.ToLower()));
        //    }

        //    var paging = await _unitOfWorkApp.Repository.HierarchyComponentRepository.FindAllPagingAsync(parametersDomain);
        //    var hierarchyComponents = await paging.Entities.ProjectTo<HierarchyComponentDto>(_mapper.ConfigurationProvider).ToListAsync();
        //    var hierarchyPaging = hierarchyComponents.Select(s => s.HierarchyName).Distinct().Select(name => new HierarchyComponentPagingDto
        //    {
        //        HierarchyName = name,
        //        HierarchyComponents = hierarchyComponents.Where(w => w.HierarchyName.ToLower().Equals(name.ToLower())).ToList()
        //    }).ToList();

        //    return new PaginationResultDto<HierarchyComponentPagingDto>
        //    {
        //        Count = hierarchyPaging.Count(),
        //        Entities = hierarchyPaging
        //    };
        //}

        public async Task<List<HierarchyComponentDto>> GetByHierarchAsync(int hierarchyId)
        {
            var hierarchyComponent = await _unitOfWorkApp.Repository.HierarchyComponentRepository
                   .Find(c => c.HierarchyId == hierarchyId)
                   .ProjectTo<HierarchyComponentDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();

            if (!hierarchyComponent.Any())
                throw new WarningException(Messages.General.ResourceNotFound);

            return hierarchyComponent;
        }
    }
}
