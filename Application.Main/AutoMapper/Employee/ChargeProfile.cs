namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Charge;
    using Domain.Main.Employee;

    public class ChargeProfile : Profile
    {
        public ChargeProfile()
        {
            CreateMap<ChargeCreateDto, Charge>().ReverseMap();
            CreateMap<ChargeUpdateDto, Charge>().ReverseMap();

            CreateMap<Charge, ChargeDto>()
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.AreaId, m => m.MapFrom(d => d.Area.Id))
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Area.Name))
                .ForMember(x => x.HierarchyId, m => m.MapFrom(d => d.Hierarchy.Id))
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Hierarchy.Name))
                .ReverseMap();
        }
    }
}
