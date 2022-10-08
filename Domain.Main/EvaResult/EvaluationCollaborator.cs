namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;
    using  Domain.Main.Collaborator;

    public class EvaluationCollaborator : BaseModel<int>
    {
        public int IdEvaluation { get; set; }
        public int IdCollaborator { get; set; }
        public int IdGerency { get; set; }
        public int IdCharge { get; set; }
        public int IdArea { get; set; }
        public int IdHierarchy { get; set; }
        public int IdLevel { get; set; }

        public Evaluation? Evaluation { get; set; }
        public Collaborator? Collaborator { get; set; }
        public Gerency? Gerency { get; set; }
        public Charge? Charge { get; set; }
        public Area? Area { get; set; }
        public Hierarchy? Hierarchy { get; set; }
        public Level? Level { get; set; }
    }
}
