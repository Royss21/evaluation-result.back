


namespace Infrastructure.UnitOfWork.Interfaces
{
    using Infrastructure.Main.Repository.Employee.Interfaces;
    using Infrastructure.Main.Repository.Config.Interfaces;
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public interface IUnitOfWorkRepository
    {
        IAreaRepository AreaRepository { get; }
        IChargeRepository ChargeRepository { get; }
        ICollaboratorRepository CollaboratorRepository { get; }
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

        IComponentCollaboratorConductRepository ComponentCollaboratorConductRepository { get; }
        IComponentCollaboratorDetailRepository ComponentCollaboratorDetailRepository { get; }
        IComponentCollaboratorRepository ComponentCollaboratorRepository { get; }
        IComponentCollaboratorCommentRepository ComponentCollaboratorCommentRepository { get; }
        IEvaluationCollaboratorRepository EvaluationCollaboratorRepository { get; }
        IEvaluationComponentRepository EvaluationComponentRepository { get; }
        IEvaluationLeaderRepository EvaluationLeaderRepository { get; }
        IEvaluationRepository EvaluationRepository { get; }
        IEvaluationComponentStageRepository EvaluationComponentStageRepository { get; }
        ILeaderCollaboratorRepository LeaderCollaboratorRepository { get; }
        ILeaderStageRepository LeaderStageRepository { get; }
        IPeriodRepository PeriodRepository { get; }
    }
}
