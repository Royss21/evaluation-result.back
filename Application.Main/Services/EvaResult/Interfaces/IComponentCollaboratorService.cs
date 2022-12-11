namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.ComponentCollaborator;

    public interface IComponentCollaboratorService
    {
        Task<bool> EvaluateAsync(ComponentCollaboratorEvaluateDto request);
        Task<ComponentCollaboratorDto> GetEvaluationDataByIdAsync(Guid id);
    }
}
