namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Collaborator.Interfaces;

    public class AreaRepository : BaseRepository<Area, int>, IAreaRepository
    {
        public AreaRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
