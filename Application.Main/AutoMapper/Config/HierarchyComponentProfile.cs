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

            CreateMap<HierarchyComponent, HierarchyComponentPagingDto>()
                .ForMember(x => x.HierarchyId, m => m.MapFrom(d => d.Hierarchy.Id))
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Hierarchy.Name))
                .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Hierarchy.Level.Name))
                .ReverseMap();

            CreateMap<HierarchyComponent, HierarchyComponentCreateDto>().ReverseMap();
            CreateMap<HierarchyComponent, HierarchyComponentPagingDto>().ReverseMap();
            CreateMap<HierarchyComponent, HierarchyComponentUpdateDto>().ReverseMap();
            CreateMap<BaseHierarchyComponentDto, HierarchyComponentUpdateDto>().ReverseMap();
            CreateMap<BaseHierarchyComponentDto, HierarchyComponentCreateDto>().ReverseMap();



        }
    }
}
