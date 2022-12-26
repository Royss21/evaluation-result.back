namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class ComponentCollaboratorDetailRepository : BaseRepository<ComponentCollaboratorDetail, int>, IComponentCollaboratorDetailRepository
    {
        public ComponentCollaboratorDetailRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
