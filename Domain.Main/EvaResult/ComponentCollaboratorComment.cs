namespace Domain.Main.EvaResult
{
    public class ComponentCollaboratorComment : BaseModel<int>
    {

        public Guid EvaluationCollaboratorId { get; set; }
        public int EvaluationComponentStageId { get; set; }
        public int StatusId { get; set; }
        public string Comment { get; set; } = string.Empty;




        public virtual EvaluationCollaborator EvaluationCollaborator { get; set; }
        public virtual EvaluationComponentStage EvaluationComponentStage { get; set; }
    }
}
