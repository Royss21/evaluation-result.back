namespace Domain.Main.EvaResult
{
    public class ComponentCollaboratorConduct : BaseModel<int>
    {

        public int ComponentCollaboratorDetailId { get; set; }
        public string LevelName { get; set; } = string.Empty;
        public decimal ConductPoints { get; set; }
        public decimal ConductPointsCalibrated { get; set; }





        public virtual ComponentCollaboratorDetail ComponentCollaboratorDetail { get; set; }
    }
}
