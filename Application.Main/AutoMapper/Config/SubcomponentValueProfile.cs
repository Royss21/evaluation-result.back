namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.SubcomponentValue;
    using Domain.Main.Config;

    public class SubcomponentValueProfile : Profile
    {
        public SubcomponentValueProfile()
        {
            CreateMap<SubcomponentValue, SubcomponentValueDto>()
                .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.Charge.Name))
                .ReverseMap();

            CreateMap<SubcomponentValueCreateDto, SubcomponentValue>();
            CreateMap<SubcomponentValueUpdateDto, SubcomponentValue>();
        }
    }
}
