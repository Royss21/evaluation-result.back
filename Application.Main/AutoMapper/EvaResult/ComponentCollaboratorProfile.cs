namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Domain.Main.EvaResult;

    public class ComponentCollaboratorProfile : Profile
    {
        public ComponentCollaboratorProfile()
        {
            CreateMap<ComponentCollaborator, ComponentCollaboratorStatusDto>()
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.StatusId, m => m.MapFrom(d => d.StatusId))
                .ReverseMap();
        }
    }
}
