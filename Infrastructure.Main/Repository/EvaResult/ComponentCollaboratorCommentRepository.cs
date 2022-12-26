namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class ComponentCollaboratorCommentRepository : BaseRepository<ComponentCollaboratorComment, int>, IComponentCollaboratorCommentRepository
    {
        public ComponentCollaboratorCommentRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
