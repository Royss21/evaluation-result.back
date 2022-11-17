namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ParameterRangeRepository : BaseRepository<ParameterRange, Guid>, IParameterRangeRepository
    {
        public ParameterRangeRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
