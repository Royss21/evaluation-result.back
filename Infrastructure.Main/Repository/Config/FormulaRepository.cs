namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class FormulaRepository : BaseRepository<Formula, Guid>, IFormulaRepository
    {
        public FormulaRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
