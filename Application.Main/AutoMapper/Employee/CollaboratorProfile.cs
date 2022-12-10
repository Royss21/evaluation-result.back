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
                .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.Charge.Name))
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Charge.Area.Name))
                .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.Charge.Area.Gerency.Name))
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Charge.Hierarchy.Name))
                .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Charge.Hierarchy.Level.Name));

            CreateMap<Collaborator, CollaboratorNotInEvaluationDto>()
                .ForMember(x => x.Id, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Charge.Area.Name))
                .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.Charge.Name))
                .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.Charge.Area.Gerency.Name))
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Charge.Hierarchy.Name))
                .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Charge.Hierarchy.Level.Name))
                .ReverseMap();
        }
    }
}
