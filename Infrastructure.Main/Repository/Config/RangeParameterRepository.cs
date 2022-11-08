namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class RangeParameterRepository : BaseRepository<RangeParameter, Guid>, IRangeParameterRepository
    {
        public RangeParameterRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
