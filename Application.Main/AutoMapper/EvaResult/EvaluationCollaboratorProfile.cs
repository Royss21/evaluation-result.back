namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Domain.Main.EvaResult;

    public class EvaluationCollaboratorProfile : Profile
    {
        public EvaluationCollaboratorProfile()
        {
            CreateMap<EvaluationCollaboratorCreateDto, EvaluationCollaborator> ().ReverseMap();
            CreateMap<EvaluationCollaborator, EvaluationCollaboratorDto>().ReverseMap();

            CreateMap<EvaluationCollaborator, EvaluationCollaboratorPagingDto>()
                .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
                .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
                .ForMember(x => x.IsLeaderCompetencies, m => m.MapFrom(d => d.EvaluationLeaders
                    .Where(el => el.EvaluationCollaboratorId.Equals(d.Id) && el.AreaName.Equals("")).Any()
                ))
                .ForMember(x => x.IsLeaderAreaObjectives, m => m.MapFrom(d => d.EvaluationLeaders
                    .Where(el => el.EvaluationCollaboratorId.Equals(d.Id) && !el.AreaName.Equals("")).Any()
                ))
                .ReverseMap();

            CreateMap<EvaluationCollaborator, EvaluationCollaboratorEvaluatePagingDto>()
                .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
                .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
                .ForMember(x => x.ComponentCollaboratorIds, m => m.MapFrom(d => d.ComponentsCollaborator.ToList().ToDictionary(x => x.EvaluationComponentId, x => x.Id)))
                .ReverseMap();

            CreateMap<EvaluationCollaborator, LeaderCollaboratorsDto>()
               .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
               .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
               .ForMember(x => x.EvaluationCollaboratorId, m => m.MapFrom(d => d.Id))
               .ForMember(x => x.AreaName, m => m.MapFrom(d => d.AreaName))
               //.ForMember(x => x.StagesName, m => m.MapFrom(d => d.LeaderCollaborators.Select(lc => lc.LeaderStage.Stage.Name)))
               .ReverseMap();
        }
    }
}
