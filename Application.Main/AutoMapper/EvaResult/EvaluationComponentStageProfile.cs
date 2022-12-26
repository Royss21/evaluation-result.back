namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.EvaluationComponentStage;
    using Domain.Main.EvaResult;

    public class EvaluationComponentStageProfile : Profile
    {
        public EvaluationComponentStageProfile()
        {
            CreateMap<EvaluationComponentStageDto, EvaluationComponentStage>().ReverseMap();
            CreateMap<EvaluationComponentStageCreateDto, EvaluationComponentStage>().ReverseMap();
        }
    }
}
