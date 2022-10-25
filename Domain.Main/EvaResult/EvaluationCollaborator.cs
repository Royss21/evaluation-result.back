namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;
    using  Domain.Main.Employee;

    public class EvaluationCollaborator : BaseModel<string>
    {
        public string EvaluationId { get; set; } = string.Empty;
        public string CollaboratorId { get; set; } = string.Empty;
        public int GerencyId { get; set; }
        public int ChargeId { get; set; }
        public int AreaId { get; set; }
        public int HierarchyId { get; set; }
        public int LevelId { get; set; }

        public Evaluation Evaluation { get; set; }
        public Collaborator Collaborator { get; set; }
        public Gerency Gerency { get; set; }
        public Charge Charge { get; set; }
        public Area Area { get; set; }
        public Hierarchy Hierarchy { get; set; }
        public Level Level { get; set; }
    }
}
