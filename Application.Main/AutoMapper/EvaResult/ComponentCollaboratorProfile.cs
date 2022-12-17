namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.EvaResult.ComponentCollaboratorConduct;
    using Application.Dto.EvaResult.ComponentCollaboratorDetail;
    using Domain.Main.EvaResult;

    public class ComponentCollaboratorProfile : Profile
    {
        public ComponentCollaboratorProfile()
        {
            CreateMap<ComponentCollaborator, ComponentCollaboratorStatusDto>()
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.StatusId, m => m.MapFrom(d => d.StatusId))
                .ReverseMap();

            CreateMap<ComponentCollaborator, ComponentCollaboratorDto>()
               .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
               .ForMember(x => x.EvaluationComponentId, m => m.MapFrom(d => d.EvaluationComponentId))
               .ForMember(x => x.StatusName, m => m.MapFrom(d => d.Status.Name))
               .ForMember(x => x.StatusId, m => m.MapFrom(d => d.StatusId))
               .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Area.Gerency.Name))
               .ForMember(x => x.AreaName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Area.Name))
               .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Name))
               .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Hierarchy.Name))
               .ForMember(x => x.LevelName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Hierarchy.Level.Name))
               .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.EvaluationCollaborator.Collaborator.Name} {d.EvaluationCollaborator.Collaborator.LastName} {d.EvaluationCollaborator.Collaborator.MiddleName}"))
               .ForMember(x => x.ComponentCollaboratorDetails, m => m.MapFrom(d => d.ComponentCollaboratorDetails
                   .Select(ccd => new ComponentCollaboratorDetailDto
                   {
                       Id = ccd.Id,
                       SubcomponentName = ccd.SubcomponentName,
                       MaximunPercentage = ccd.MaximunPercentage,
                       MinimunPercentage = ccd.MinimunPercentage,
                       ComponentCollaboratorConducts = ccd.ComponentCollaboratorConducts.Select(ccc => new ComponentCollaboratorConductDto
                       {
                           Id = ccc.Id,
                           ConductDescription = ccc.ConductDescription
                       }).ToList()
                   }).ToList()
               ))
               .ReverseMap();


            CreateMap<ComponentCollaborator, ComponentCollaboratorPagingDto>()
            .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.EvaluationCollaborator.Collaborator.Name} {d.EvaluationCollaborator.Collaborator.LastName} {d.EvaluationCollaborator.Collaborator.MiddleName}"))
            .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.DocumentNumber))
            .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Area.Gerency.Name))
            .ForMember(x => x.AreaName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Area.Name))
            .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Name))
            .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Hierarchy.Name))
            .ForMember(x => x.LevelName, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.Charge.Hierarchy.Level.Name))
            .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
            .ForMember(x => x.StatusId, m => m.MapFrom(d => d.StatusId))
            .ReverseMap();
        }
    }
}
