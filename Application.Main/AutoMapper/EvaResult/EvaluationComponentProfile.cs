namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.EvaluationComponent;
    using Domain.Main.EvaResult;

    public class EvaluationComponentProfile : Profile
    {
        public EvaluationComponentProfile()
        {
            CreateMap<EvaluationComponentDto, EvaluationComponent>().ReverseMap();
            CreateMap<EvaluationComponentCreateDto, EvaluationComponent>().ReverseMap();
        }
    }
}
