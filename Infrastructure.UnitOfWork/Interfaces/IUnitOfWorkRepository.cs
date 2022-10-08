


namespace Infrastructure.UnitOfWork.Interfaces
{
    using Infrastructure.Main.Repository.Collaborator.Interfaces;
    using Infrastructure.Main.Repository.Config.Interfaces;

    public interface IUnitOfWorkRepository
    {
        IAreaRepository AreaRepository { get; }
        IChargeRepository ChargeRepository { get; }
        IGerencyRepository GerencyRepository { get; }
        IHierarchyRepository HierarchyRepository { get; }
        IComponentRepository ComponentRepository { get; }
        IConductRepository ConductRepository { get; }
        IHierarchyComponentRepository HierarchyComponentRepository { get; }
        ILabelRepository LabelRepository { get; }
        ILabelDetailRepository LabelDetailRepository { get; }
        ILevelRepository LevelRepository { get; }
        IStageRepository StageRepository { get; }
        ISubcomponentRepository SubcomponentRepository { get; }
        ISubcomponentValueRepository SubcomponentValueRepository { get; }
    }
}
