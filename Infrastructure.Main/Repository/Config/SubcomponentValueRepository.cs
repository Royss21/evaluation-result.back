namespace Infrastructure.Main.Repository.Config
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class SubcomponentValueRepository : BaseRepository<SubcomponentValue, string>, ISubcomponentValueRepository
    {
        public SubcomponentValueRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
