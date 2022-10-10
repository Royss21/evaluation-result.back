namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class ComponentCollaboratorRepository : BaseRepository<ComponentCollaborator, string>, IComponentCollaboratorRepository
    {
        public ComponentCollaboratorRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
