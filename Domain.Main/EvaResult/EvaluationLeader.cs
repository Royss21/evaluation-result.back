namespace Domain.Main.EvaResult
{
    using Domain.Main.Collaborator;


    public class EvaluationLeader : BaseModel<int>
    {
        public int IdEvaluationCollaborator { get; set; }
        public int IdArea { get; set; }
       

        public EvaluationCollaborator? EvaluationCollaborator { get; set; }
        public Area? Area { get; set; }
    }
}
