namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.Pagination;

    public interface IComponentCollaboratorService
    {
        Task<bool> EvaluateAsync(ComponentCollaboratorEvaluateDto request);
        Task<ComponentCollaboratorDto> GetEvaluationDataByIdAsync(Guid id);
        Task<PaginationResultDto<ComponentCollaboratorPagingDto>> GetPagingAsync(ComponentCollaboratorFilterDto filter);
    }
}
