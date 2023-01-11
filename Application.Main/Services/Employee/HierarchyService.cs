namespace Application.Main.Services.Employee
{
    using System;
    using Domain.Main.Employee;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Domain.Common.Constants;
    using Application.Dto.Pagination;
    using System.Collections.Generic;
    using Application.Main.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Dto.Employee.Hierarchy;
    using Application.Main.Services.Employee.Interfaces;
    using Application.Main.Services.Employee.Validators;
    using Domain.Main.Config;

    public class HierarchyService : BaseService, IHierarchyService
    {
        public HierarchyService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<HierarchyDto> CreateAsync(HierarchyCreateDto request)
        {
            var hierarchy = _mapper.Map<Hierarchy>(request);
            var components = await _unitOfWorkApp.Repository.ComponentRepository.All().ToListAsync();
            
            hierarchy.HierarchyComponents = components.Select(comp => new HierarchyComponent 
                { ComponentId = comp.Id }).ToList();

            var resultValidator = await _unitOfWorkApp.Repository.HierarchyRepository
                .AddAsync(hierarchy, new HierarchyCreateUpdateValidation(_unitOfWorkApp.Repository.HierarchyRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();
            return _mapper.Map<HierarchyDto>(hierarchy);
        }

        public async Task<bool> UpdateAsync(HierarchyUpdateDto request)
        {
            var hierarchy = _mapper.Map<Hierarchy>(request);
            var resultValidator = await _unitOfWorkApp.Repository.HierarchyRepository
                .UpdateAsync(hierarchy, new HierarchyCreateUpdateValidation(_unitOfWorkApp.Repository.HierarchyRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<HierarchyDto>> GetAllAsync()
        {
            var hierarchy = await _unitOfWorkApp.Repository.HierarchyRepository
                .All()
                .ProjectTo<HierarchyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return hierarchy;
        }

        public async Task<PaginationResultDto<HierarchyDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<HierarchyDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Hierarchy, HierarchyDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                            add.Level.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.HierarchyRepository.FindAllPagingAsync(parametersDomain);
            var hierarchies = await paging.Entities.ProjectTo<HierarchyDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<HierarchyDto>
            {
                Count = paging.Count,
                Entities = hierarchies
            };
        }

        public async Task<HierarchyDto> GetByIdAsync(int id)
        {
            var hierarchy = await _unitOfWorkApp.Repository.HierarchyRepository
                    .Find(c => c.Id == id)
                    .ProjectTo<HierarchyDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (hierarchy is null)
                throw new Exceptions.WarningException(Messages.General.ResourceNotFound);

            return hierarchy;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hierarchy = await _unitOfWorkApp.Repository.HierarchyRepository.GetAsync(id);

            if (hierarchy is null)
                throw new System.ComponentModel.WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.HierarchyRepository.DeleteAsync(hierarchy);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
    }
}
