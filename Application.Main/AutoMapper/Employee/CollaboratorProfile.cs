namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.Employee;
    using Domain.Main.Employee;

    public class CollaboratorProfile : Profile
    {
        public CollaboratorProfile()
        {
            CreateMap<CollaboratorDto, Collaborator>().ReverseMap();
            CreateMap<CollaboratorCreateDto, Collaborator>().ReverseMap();
            CreateMap<CollaboratorUpdateDto, Collaborator>().ReverseMap();
        }
    }
}
