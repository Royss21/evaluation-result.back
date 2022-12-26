namespace Infrastructure.Main.Repository.EvaResult
{
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class EvaluationCollaboratorRepository : BaseRepository<EvaluationCollaborator, Guid>, IEvaluationCollaboratorRepository
    {
        public EvaluationCollaboratorRepository(DbContextMain dbContextMain) : base(dbContextMain)
        {

        }
    }
}
