namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class SubcomponentValueRepository : BaseRepository<SubcomponentValue, string>, ISubcomponentValueRepository
    {
        public SubcomponentValueRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
