namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class ComponentCollaboratorConductRepository : BaseRepository<ComponentCollaboratorConduct, int>, IComponentCollaboratorConductRepository
    {
        public ComponentCollaboratorConductRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
