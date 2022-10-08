
namespace Infrastructure.UnitOfWork
{
    using Infrastructure.Main.Context;
    using Infrastructure.Main.Repository.Collaborator;
    using Infrastructure.Main.Repository.Collaborator.Interfaces;
    using Infrastructure.Main.Repository.Config.Interfaces;
    using Infrastructure.UnitOfWork.Interfaces;

    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IAreaRepository AreaRepository { get; }
        public IChargeRepository ChargeRepository { get; }
        public IGerencyRepository GerencyRepository { get; }
        public IHierarchyRepository HierarchyRepository { get; }
        public IComponentRepository ComponentRepository { get; }
        public IConductRepository ConductRepository { get; }
        public IHierarchyComponentRepository HierarchyComponentRepository { get; }
        public ILabelRepository LabelRepository { get; }
        public ILabelDetailRepository LabelDetailRepository { get; }
        public ILevelRepository LevelRepository { get; }
        public IStageRepository StageRepository { get; }
        public ISubcomponentRepository SubcomponentRepository { get; }
        public ISubcomponentValueRepository SubcomponentValueRepository { get; }

        public UnitOfWorkRepository(DbContextMain context)
        {
            ChargeRepository = new ChargeRepository(context);
            AreaRepository = new AreaRepository(context);
            GerencyRepository = new GerencyRepository(context);
            HierarchyRepository = new HierarchyRepository(context);
            ComponentRepository = new ComponentRepository(context);
            ConductRepository = new ConductRepository(context);
            HierarchyComponentRepository = new HierarchyComponentRepository(context);
            LabelRepository = new LabelRepository(context);
            LabelDetailRepository = new LabelDetailRepository(context);
            LevelRepository = new LevelRepository(context);
            StageRepository = new StageRepository(context);
            SubcomponentRepository = new SubcomponentRepository(context);
            SubcomponentValueRepository = new SubcomponentValueRepository(context);
        }
    }
}