namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.HierarchyComponent;
    using Application.Dto.Employee.Hierarchy;
    using Domain.Main.Employee;

    public class HierarchyProfile : Profile
    {
        public HierarchyProfile()
        {
            CreateMap<HierarchyCreateDto, Hierarchy>().ReverseMap();
            CreateMap<HierarchyUpdateDto, Hierarchy>().ReverseMap();

            CreateMap<Hierarchy, HierarchyDto>()
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.LevelId, m => m.MapFrom(d => d.Level.Id))
                .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Level.Name))
                .ForMember(x => x.Name, m => m.MapFrom(d => d.Name))
                .ForMember(x => x.HierarchyComponents, m => m.MapFrom(d => 
                    d.HierarchyComponents.Select(comp => new HierarchyComponentDto { Id = comp.Id, ComponentId = comp.ComponentId, Weight = comp.Weight })))
                .ReverseMap();
        }
    }
}
