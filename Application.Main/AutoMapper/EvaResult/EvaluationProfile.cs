namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.Evaluation;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;

    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            CreateMap<EvaluationDto, Evaluation>().ReverseMap();
            CreateMap<EvaluationCreateDto, Evaluation>().ReverseMap();
            CreateMap<Evaluation, EvaluationInProgressDto>()
                .ForMember(x => x.HasComponentCorporateObjectives, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.CorporateObjectives)))
                .ForMember(x => x.HasComponentAreaObjectives, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives)))
                .ForMember(x => x.HasComponentCompetencies, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies)))
                .ForMember(x => x.PeriodName, m => m.MapFrom(d => d.Period.Name))
                .ForMember(x => x.EvaluationName, m => m.MapFrom(d => d.Name))
                .ForMember(x => x.RangeDate, m => m.MapFrom(d => $"{d.StartDate.ToString("dd [P1] MMMMM, yyyy")} - {d.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de")));
        }
    }
}
