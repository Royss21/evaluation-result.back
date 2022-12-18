namespace Application.Main.Services.Employee
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Domain.Common.Constants;
    using System.Collections.Generic;
    using Application.Main.Service.Base;
    using Application.Dto.Employee.Hierarchy;
    using Application.Main.Services.Employee.Interfaces;

    public class HierarchyService : BaseService, IHierarchyService
    {
        public HierarchyService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<IEnumerable<HierarchyDto>> GetAllAsync()
        {
            var hierarchy = await _unitOfWorkApp.Repository.HierarchyRepository
                .All()
                .ProjectTo<HierarchyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return hierarchy;
        }

        public async Task<HierarchyDto> GetByIdAsync(int id)
        {
            var hierarchy = await _unitOfWorkApp.Repository.HierarchyRepository
                    .Find(c => c.Id == id)
                    .ProjectTo<HierarchyDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (hierarchy is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            return hierarchy;
        }
    }
}
