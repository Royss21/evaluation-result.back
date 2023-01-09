namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Domain.Main.EvaResult;

    public class EvaluationCollaboratorProfile : Profile
    {
        public EvaluationCollaboratorProfile()
        {
            CreateMap<EvaluationCollaboratorCreateDto, EvaluationCollaborator>().ReverseMap();
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

            CreateMap<EvaluationCollaborator, LeaderCollaboratorsDto>()
               .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
               .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
               .ForMember(x => x.EvaluationCollaboratorId, m => m.MapFrom(d => d.Id))
               .ForMember(x => x.AreaName, m => m.MapFrom(d => d.AreaName))
               .ReverseMap();

            CreateMap<EvaluationCollaborator, EvaluationCollaboratorResultDto>()
              .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Gerency.Name))
              .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Name))
              .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.Collaborator.Charge.Name))
              .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Name))
              .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Level.Name))
              .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
              .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"));


            CreateMap<EvaluationCollaborator, EvaluationCollaboratorReviewPagingDto>()
                .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
                .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
                .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Gerency.Name))
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Name))
                .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.Collaborator.Charge.Name))
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Name))
                .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Level.Name))
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id));
        }
    }
}
