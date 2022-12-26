namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.Period;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;

    public class PeriodProfile : Profile
    {
        public PeriodProfile()
        {
            CreateMap<PeriodDto, Period>().ReverseMap();
            CreateMap<PeriodCreateDto, Period>().ReverseMap();
            CreateMap<PeriodUpdateDto, Period>().ReverseMap();

            CreateMap<Period, PeriodInProgressDto>()
               .ForMember(x => x.PeriodName, m => m.MapFrom(d => d.Name))
               .ForMember(x => x.PeriodId, m => m.MapFrom(d => d.Id));
        }
    }
}
