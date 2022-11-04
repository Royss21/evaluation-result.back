namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.EvaluationLeader;

    public interface IEvaluationLeaderService
    {
        Task<bool> ImportBulkAsync(EvaluationLeaderFileDto request);
    }
}
