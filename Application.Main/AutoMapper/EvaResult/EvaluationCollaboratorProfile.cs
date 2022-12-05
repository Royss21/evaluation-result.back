namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Domain.Main.EvaResult;

    public class EvaluationCollaboratorProfile : Profile
    {
        public EvaluationCollaboratorProfile()
        {
            CreateMap<EvaluationCollaborator, EvaluationCollaboratorPagingDto>().ReverseMap();
            CreateMap<EvaluationCollaboratorCreateDto, EvaluationCollaborator> ().ReverseMap();
            CreateMap<EvaluationCollaborator, EvaluationCollaboratorDto>().ReverseMap();

            CreateMap<EvaluationCollaborator, LeaderCollaboratorsDto>()
               .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
               .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
               .ForMember(x => x.AreaName, m => m.MapFrom(d => d.AreaName))
               .ForMember(x => x.StagesName, m => m.MapFrom(d => d.LeaderCollaborators.Select(lc => lc.LeaderStage.Stage.Name)))
               .ReverseMap();
        }
    }
}
