namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.Collaborator;
    using Application.Dto.Pagination;

    public interface ICollaboratorService
    {
        Task<IEnumerable<CollaboratorNotInEvaluationDto>> GetAllCollaboratorNotInEvaluationAsync(Guid evaluationId);
        Task<PaginationResultDto<CollaboratorNotInEvaluationDto>> GetAllPagingCollaboratorNotInEvaluationAsync(PagingFilterDto primeTable);

    }
}
