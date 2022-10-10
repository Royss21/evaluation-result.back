namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class EvaluationRepository : BaseRepository<Evaluation, string>, IEvaluationRepository
    {
        public EvaluationRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
