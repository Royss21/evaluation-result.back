namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;


    public class ComponentCollaboratorStage : BaseModel<Guid>
    {
        public Guid ComponentCollaboratorId { get; set; }
        public int StageId { get; set; }
        public string Comment { get; set; } = string.Empty;





        public virtual ComponentCollaborator ComponentCollaborator { get; set; }
        public virtual Stage Stage { get; set; }

    }
}
