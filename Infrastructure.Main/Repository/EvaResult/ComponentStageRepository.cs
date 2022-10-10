namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class ComponentStageRepository : BaseRepository<ComponentStage, int>, IComponentStageRepository
    {
        public ComponentStageRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
