namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.Area;
    using Application.Dto.Employee.Collaborator;
    using Application.Dto.Pagination;
    using Application.Main.PrimeNg;

    public interface ICollaboratorService
    {
        Task<IEnumerable<CollaboratorNotInEvaluationDto>> GetAllCollaboratorNotInEvaluationAsync(Guid evaluationId);
    }
}
