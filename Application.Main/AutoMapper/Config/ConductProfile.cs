namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.Conduct;
    using Domain.Main.Config;

    public class ConductProfile : Profile
    {
        public ConductProfile()
        {
            CreateMap<ConductCreateDto, Conduct>().ReverseMap();
            CreateMap<ConductDto, Conduct>().ReverseMap();
            CreateMap<ConductUpdateDto, Conduct>().ReverseMap();
        }
    }
}
