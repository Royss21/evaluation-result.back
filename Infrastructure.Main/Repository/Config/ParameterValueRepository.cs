namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ParameterValueRepository : BaseRepository<ParameterValue, int>, IParameterValueRepository
    {
        public ParameterValueRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
