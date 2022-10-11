namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Area;
    using Domain.Main.Employee;

    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaDto, Area>().ReverseMap();
            CreateMap<AreaCreateDto, Area>().ReverseMap();
            CreateMap<AreaUpdateDto, Area>().ReverseMap();
        }
    }
}
