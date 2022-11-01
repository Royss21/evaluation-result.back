namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.Evaluation;
    using Domain.Main.EvaResult;

    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            CreateMap<EvaluationDto, Evaluation>().ReverseMap();
            CreateMap<EvaluationCreateDto, Evaluation>().ReverseMap();
        }
    }
}
