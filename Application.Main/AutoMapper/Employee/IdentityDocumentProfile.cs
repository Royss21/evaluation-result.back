namespace Application.Main.AutoMapper.Employee
{
    using Application.Dto.Employee.IdentityDocument;
    using Domain.Main.Employee;

    public class IdentityDocumentProfile : Profile
    {
        public IdentityDocumentProfile()
        {

            CreateMap<IdentityDocument, IdentityDocumentDto>()
             .ReverseMap();
        }
    }
}
