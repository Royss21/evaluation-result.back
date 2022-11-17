namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.HierarchyComponent;
    using Domain.Main.Config;

    public class HierarchyComponentProfile : Profile
    {
        public HierarchyComponentProfile()
        {
            CreateMap<HierarchyComponent, HierarchyComponentDto>()
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Hierarchy.Name))
                .ForMember(x => x.ComponentName, m => m.MapFrom(d => d.Component.Name))
                .ReverseMap();

            CreateMap<HierarchyComponent, HierarchyComponentCreateDto>().ReverseMap();
            CreateMap<HierarchyComponent, HierarchyComponentPagingDto>().ReverseMap();
            CreateMap<HierarchyComponent, HierarchyComponentUpdateDto>().ReverseMap();
        }
    }
}
