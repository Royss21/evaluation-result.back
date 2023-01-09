namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.Collaborator;
    using Application.Dto.Pagination;

    public interface ICollaboratorService
    {
        Task<IEnumerable<CollaboratorNotInEvaluationDto>> GetAllCollaboratorNotInEvaluationAsync(Guid evaluationId);        
        Task<bool> UpdateAsync(CollaboratorUpdateDto request);
        Task<CollaboratorDto> CreateAsync(CollaboratorCreateDto request);
        Task<bool> DeleteAsync(Guid id);
        Task<PaginationResultDto<CollaboratorDto>> GetAllPagingAsync(PagingFilterDto primeTable);

    }
}
