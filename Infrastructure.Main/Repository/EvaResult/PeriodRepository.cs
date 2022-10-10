namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class PeriodRepository : BaseRepository<Period, int>, IPeriodRepository
    {
        public PeriodRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
