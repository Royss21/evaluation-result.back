namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class ComponentCollaboratorRepository : BaseRepository<ComponentCollaborator, Guid>, IComponentCollaboratorRepository
    {
        public ComponentCollaboratorRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
