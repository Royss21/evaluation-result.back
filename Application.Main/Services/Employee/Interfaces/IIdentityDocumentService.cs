namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.IdentityDocument;

    public interface IIdentityDocumentService
    {
        Task<IEnumerable<IdentityDocumentDto>> GetAllAsync();
    }
}
