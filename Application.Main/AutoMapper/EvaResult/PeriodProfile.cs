namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.Period;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;
    using static iTextSharp.text.pdf.qrcode.Version;

    public class PeriodProfile : Profile
    {
        public PeriodProfile()
        {
            CreateMap<Period, PeriodDto>()
            .ForMember(x => x.RangeDate, m => m.MapFrom(ecs => "Desde el " + $"{ecs.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta el {ecs.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de")));
            //RangeDate = "Desde el " + $"{ecs.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta el {ecs.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de"),
            CreateMap<PeriodCreateDto, Period>().ReverseMap();
            CreateMap<PeriodUpdateDto, Period>().ReverseMap();

            CreateMap<Period, PeriodInProgressDto>()
               .ForMember(x => x.PeriodName, m => m.MapFrom(d => d.Name))
               .ForMember(x => x.PeriodId, m => m.MapFrom(d => d.Id));
        }
    }
}
