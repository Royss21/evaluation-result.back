namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;


    public class ComponentCollaboratorStage : BaseModel<string>
    {
        public int IdComponentCollaborator { get; set; }
        public int IdStage { get; set; }
        public string Comment { get; set; } = string.Empty;


        public ComponentCollaborator ComponentCollaborator { get; set; }
        public Stage Stage { get; set; }

    }
}
