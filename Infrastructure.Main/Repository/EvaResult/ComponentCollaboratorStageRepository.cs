namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class ComponentCollaboratorStageRepository : BaseRepository<ComponentCollaboratorStage, string>, IComponentCollaboratorStageRepository
    {
        public ComponentCollaboratorStageRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
