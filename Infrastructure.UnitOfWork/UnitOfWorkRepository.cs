﻿
namespace Infrastructure.UnitOfWork
{
    using Infrastructure.Main.Context;
    using Infrastructure.UnitOfWork.Interfaces;
    using Infrastructure.Main.Repository.Config.Interfaces;
    using Infrastructure.Main.Repository.Employee.Interfaces;
    using Infrastructure.Main.Repository.Employee;
    using Infrastructure.Main.Repository.Config;
    using Infrastructure.Main.Repository.EvaResult.Interfaces;
    using Infrastructure.Main.Repository.EvaResult;

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

        public ICollaboratorRepository CollaboratorRepository { get; }
        public IComponentCollaboratorConductRepository ComponentCollaboratorConductRepository { get; }
        public IComponentCollaboratorDetailRepository ComponentCollaboratorDetailRepository { get; }
        public IComponentCollaboratorRepository ComponentCollaboratorRepository { get; }
        public IComponentCollaboratorStageRepository ComponentCollaboratorStageRepository { get; }
        public IComponentStageRepository ComponentStageRepository { get; }
        public IEvaluationCollaboratorRepository EvaluationCollaboratorRepository { get; }
        public IEvaluationComponentRepository EvaluationComponentRepository { get; }
        public IEvaluationLeaderRepository EvaluationLeaderRepository { get; }
        public IEvaluationRepository EvaluationRepository { get; }
        public IEvaluationStageRepository EvaluationStageRepository { get; }
        public ILeaderCollaboratorRepository LeaderCollaboratorRepository { get; }
        public ILeaderStageRepository LeaderStageRepository { get; }
        public IPeriodRepository PeriodRepository { get; }

        public UnitOfWorkRepository(DbContextMain context)
        {
            ChargeRepository = new ChargeRepository(context);
            AreaRepository = new AreaRepository(context);
            GerencyRepository = new GerencyRepository(context);
            HierarchyRepository = new HierarchyRepository(context);
            ComponentRepository = new ComponentRepository(context);
            CollaboratorRepository = new CollaboratorRepository(context);
            ConductRepository = new ConductRepository(context);
            HierarchyComponentRepository = new HierarchyComponentRepository(context);
            LabelRepository = new LabelRepository(context);
            LabelDetailRepository = new LabelDetailRepository(context);
            LevelRepository = new LevelRepository(context);
            StageRepository = new StageRepository(context);
            SubcomponentRepository = new SubcomponentRepository(context);
            SubcomponentValueRepository = new SubcomponentValueRepository(context);
            ComponentCollaboratorConductRepository = new ComponentCollaboratorConductRepository(context);
            ComponentCollaboratorDetailRepository = new ComponentCollaboratorDetailRepository(context);
            ComponentCollaboratorRepository = new ComponentCollaboratorRepository(context);
            ComponentCollaboratorStageRepository = new ComponentCollaboratorStageRepository(context);
            ComponentStageRepository = new ComponentStageRepository(context);
            EvaluationCollaboratorRepository = new EvaluationCollaboratorRepository(context);
            EvaluationComponentRepository = new EvaluationComponentRepository(context);
            EvaluationLeaderRepository = new EvaluationLeaderRepository(context);
            EvaluationRepository = new EvaluationRepository(context);
            EvaluationStageRepository = new EvaluationStageRepository(context);
            LeaderCollaboratorRepository = new LeaderCollaboratorRepository(context);
            LeaderStageRepository = new LeaderStageRepository(context);
            PeriodRepository = new PeriodRepository(context);
        }
    }
}