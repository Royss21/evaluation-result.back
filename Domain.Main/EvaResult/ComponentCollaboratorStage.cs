namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;


    public class ComponentCollaboratorStage : BaseModel<string>
    {
        public string ComponentCollaboratorId { get; set; }
        public int StageId { get; set; }
        public string Comment { get; set; } = string.Empty;


        public ComponentCollaborator ComponentCollaborator { get; set; }
        public Stage Stage { get; set; }

    }
}
