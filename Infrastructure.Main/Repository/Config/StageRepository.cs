namespace Infrastructure.Main.Repository.Collaborator
{
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class StageRepository : BaseRepository<Stage, int>, IStageRepository
    {
        public StageRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
