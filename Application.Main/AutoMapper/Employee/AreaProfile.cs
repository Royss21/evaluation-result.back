namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Area;
    using Domain.Main.Employee;

    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaCreateDto, Area>().ReverseMap();
            CreateMap<AreaUpdateDto, Area>().ReverseMap();

            CreateMap<Area, AreaDto>()
             .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
             .ForMember(x => x.Name, m => m.MapFrom(d => d.Name))
             .ForMember(x => x.GerencyId, m => m.MapFrom(d => d.Gerency.Id))
             .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.Gerency.Name))
             .ReverseMap();
        }
    }
}
