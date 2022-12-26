namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Config.ParameterValue;
    using Domain.Main.Config;

    public class ParameterValueProfile : Profile
    {
        public ParameterValueProfile()
        {
            CreateMap<ParameterValueCreateDto, ParameterValue>().ReverseMap();
            CreateMap<ParameterValueDto, ParameterValue>().ReverseMap();
            CreateMap<ParameterValueUpdateDto, ParameterValue>().ReverseMap();
        }
    }
}
