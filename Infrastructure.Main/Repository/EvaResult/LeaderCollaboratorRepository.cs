namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class LeaderCollaboratorRepository : BaseRepository<LeaderCollaborator, int>, ILeaderCollaboratorRepository
    {
        public LeaderCollaboratorRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
