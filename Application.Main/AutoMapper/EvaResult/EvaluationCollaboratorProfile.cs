namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Domain.Main.EvaResult;

    public class EvaluationCollaboratorProfile : Profile
    {
        public EvaluationCollaboratorProfile()
        {
            CreateMap<EvaluationCollaborator, EvaluationCollaboratorPagingDto>().ReverseMap();
            CreateMap<EvaluationCollaboratorCreateDto, EvaluationCollaborator> ().ReverseMap();
            CreateMap<EvaluationCollaborator, EvaluationCollaboratorDto>().ReverseMap();
        }
    }
}
