
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
    using Infrastructure.Main.Repository.Security.Interfaces;
    using Infrastructure.Main.Repository.Security;

    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IAreaRepository AreaRepository { get; }
        public IChargeRepository ChargeRepository { get; }
        public IGerencyRepository GerencyRepository { get; }
        public IHierarchyRepository HierarchyRepository { get; }
        public IIdentityDocumentRepository IdentityDocumentRepository { get; }
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
        public IComponentCollaboratorCommentRepository ComponentCollaboratorCommentRepository { get; }
        public IEvaluationCollaboratorRepository EvaluationCollaboratorRepository { get; }
        public IEvaluationComponentRepository EvaluationComponentRepository { get; }
        public IEvaluationLeaderRepository EvaluationLeaderRepository { get; }
        public IEvaluationRepository EvaluationRepository { get; }
        public IEvaluationComponentStageRepository EvaluationComponentStageRepository { get; }
        public ILeaderCollaboratorRepository LeaderCollaboratorRepository { get; }
        public ILeaderStageRepository LeaderStageRepository { get; }
        public IPeriodRepository PeriodRepository { get; }
        public IFormulaRepository FormulaRepository { get; }
        public IParameterRangeRepository ParameterRangeRepository { get; }
        public IParameterValueRepository ParameterValueRepository { get; }

        public IEndpointRepository EndpointRepository { get; }
        public IMenuRepository MenuRepository { get; }
        public IRoleMenuRepository RoleMenuRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserEndpointLockedRepository UserEndpointLockedRepository { get; }
        public IUserRepository UserRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IUserTokenRepository UserTokenRepository { get; }

        public UnitOfWorkRepository(DbContextMain context)
        {
            ChargeRepository = new ChargeRepository(context);
            AreaRepository = new AreaRepository(context);
            GerencyRepository = new GerencyRepository(context);
            HierarchyRepository = new HierarchyRepository(context);
            IdentityDocumentRepository = new IdentityDocumentRepository(context);
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
            ComponentCollaboratorCommentRepository = new ComponentCollaboratorCommentRepository(context);
            EvaluationCollaboratorRepository = new EvaluationCollaboratorRepository(context);
            EvaluationComponentRepository = new EvaluationComponentRepository(context);
            EvaluationLeaderRepository = new EvaluationLeaderRepository(context);
            EvaluationRepository = new EvaluationRepository(context);
            EvaluationComponentStageRepository = new EvaluationComponentStageRepository(context);
            LeaderCollaboratorRepository = new LeaderCollaboratorRepository(context);
            LeaderStageRepository = new LeaderStageRepository(context);
            PeriodRepository = new PeriodRepository(context);
            FormulaRepository = new FormulaRepository(context);
            ParameterValueRepository = new ParameterValueRepository(context);
            ParameterRangeRepository = new ParameterRangeRepository(context);

            EndpointRepository = new EndpointRepository(context);
            MenuRepository = new MenuRepository(context);
            RoleMenuRepository = new RoleMenuRepository(context);
            RoleRepository = new RoleRepository(context);
            UserEndpointLockedRepository = new UserEndpointLockedRepository(context);
            UserRepository = new UserRepository(context);
            UserRoleRepository = new UserRoleRepository(context);
            UserTokenRepository = new UserTokenRepository(context);
        }
    }
}