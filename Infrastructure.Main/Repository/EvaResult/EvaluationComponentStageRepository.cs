namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class EvaluationComponentStageRepository : BaseRepository<EvaluationComponentStage, int>, IEvaluationComponentStageRepository
    {
        public EvaluationComponentStageRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
