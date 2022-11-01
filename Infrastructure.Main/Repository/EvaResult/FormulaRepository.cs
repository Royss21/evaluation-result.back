namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class FormulaRepository : BaseRepository<Formula, Guid>, IFormulaRepository
    {
        public FormulaRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
