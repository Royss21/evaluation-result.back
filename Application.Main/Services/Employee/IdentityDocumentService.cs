namespace Application.Main.Services.Employee
{
    using Application.Dto.Employee.IdentityDocument;
    using Application.Main.Service.Base;
    using Application.Main.Services.Employee.Interfaces;

    public class IdentityDocumentService : BaseService, IIdentityDocumentService
    {
        public IdentityDocumentService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

       
        public async Task<IEnumerable<IdentityDocumentDto>> GetAllAsync()
        {
            var documents = await _unitOfWorkApp.Repository.IdentityDocumentRepository
                    .All()
                    .ProjectTo<IdentityDocumentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return documents;
        }
    }
}
