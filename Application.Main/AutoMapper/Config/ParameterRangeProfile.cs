namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.ParameterRange;
    using Domain.Main.Config;

    public class ParameterRangeProfile : Profile
    {
        public ParameterRangeProfile()
        {
            CreateMap<ParameterRangeCreateDto, ParameterRange>().ReverseMap();
            CreateMap<ParameterRangeDto, ParameterRange>().ReverseMap();
            CreateMap<ParameterRangeUpdateDto, ParameterRange>().ReverseMap();
        }
    }
}
