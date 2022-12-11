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
               .ForMember(x => x.ComponentCollaboratorDetails, m => m.MapFrom(d => d.ComponentCollaboratorDetails
                   .Select(ccd => new ComponentCollaboratorDetailDto
                   {
                       Id = ccd.Id,
                       SubcomponentName = ccd.SubcomponentName,
                       ComponentCollaboratorConducts = ccd.ComponentCollaboratorConducts.Select(ccc => new ComponentCollaboratorConductDto
                       {
                           Id = ccc.Id,
                           ConductDescription = ccc.ConductDescription
                       }).ToList()
                   }).ToList()
               ))
               .ReverseMap();
        }
    }
}
