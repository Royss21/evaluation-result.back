namespace Domain.Main.EvaResult
{
    using Domain.Main.Employee;


    public class EvaluationLeader : BaseModel<int>
    {
        public string EvaluationCollaboratorId { get; set; } = string.Empty;
        public int? AreaId { get; set; }
       

        public EvaluationCollaborator EvaluationCollaborator { get; set; }
        public Area? Area { get; set; }
    }
}
