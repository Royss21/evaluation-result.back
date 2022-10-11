namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Gerency;
    using Domain.Main.Employee;

    public class GerencyProfile : Profile
    {
        public GerencyProfile()
        {
            CreateMap<GerencyDto, Gerency>().ReverseMap();
            CreateMap<GerencyCreateDto, Gerency>().ReverseMap();
            CreateMap<GerencyUpdateDto, Gerency>().ReverseMap();
        }
    }
}
