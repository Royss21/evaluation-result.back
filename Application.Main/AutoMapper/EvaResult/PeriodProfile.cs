namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.Period;
    using Domain.Main.EvaResult;

    public class PeriodProfile : Profile
    {
        public PeriodProfile()
        {
            CreateMap<PeriodDto, Period>().ReverseMap();
            CreateMap<PeriodCreateDto, Period>().ReverseMap();
            CreateMap<PeriodUpdateDto, Period>().ReverseMap();
        }
    }
}
