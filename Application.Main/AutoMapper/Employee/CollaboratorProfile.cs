namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Collaborator;
    using Domain.Main.Employee;

    public class CollaboratorProfile : Profile
    {
        public CollaboratorProfile()
        {
            CreateMap<CollaboratorDto, Collaborator>().ReverseMap();
            CreateMap<CollaboratorCreateDto, Collaborator>().ReverseMap();
            CreateMap<CollaboratorUpdateDto, Collaborator>().ReverseMap();

            CreateMap<Collaborator, CollaboratorsToEvaluateDto>()
                .ForMember(x => x.CollaboratorId, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.ChargeId, m => m.MapFrom(d => d.ChargeId))
                .ForMember(x => x.AreaId, m => m.MapFrom(d => d.Charge.AreaId))
                .ForMember(x => x.GerencyId, m => m.MapFrom(d => d.Charge.Area.GerencyId))
                .ForMember(x => x.HierarchyId, m => m.MapFrom(d => d.Charge.HierarchyId))
                .ForMember(x => x.LevelId, m => m.MapFrom(d => d.Charge.Hierarchy.LevelId));
        }
    }
}
