namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Charge;
    using Domain.Main.Employee;

    public class ChargeProfile : Profile
    {
        public ChargeProfile()
        {
            CreateMap<ChargeDto, Charge>().ReverseMap();
            CreateMap<ChargeCreateDto, Charge>().ReverseMap();
            CreateMap<ChargeUpdateDto, Charge>().ReverseMap();
        }
    }
}
