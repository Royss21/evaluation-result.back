namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class EvaluationComponentRepository : BaseRepository<EvaluationComponent, int>, IEvaluationComponentRepository
    {
        public EvaluationComponentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
