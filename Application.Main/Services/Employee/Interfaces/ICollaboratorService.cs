namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.Collaborator;
    using Application.Dto.Pagination;

    public interface ICollaboratorService
    {
        Task<CollaboratorNotInEvaluationDto> CreateAsync(CollaboratorNotInEvaluationCreateDto request);
        Task<IEnumerable<CollaboratorNotInEvaluationDto>> GetAllCollaboratorNotInEvaluationAsync(Guid evaluationId);
        Task<bool> UpdateAsync(CollaboratorUpdateDto request);
        Task<PaginationResultDto<CollaboratorNotInEvaluationDto>> GetAllPagingCollaboratorNotInEvaluationAsync(PagingFilterDto primeTable);

    }
}
