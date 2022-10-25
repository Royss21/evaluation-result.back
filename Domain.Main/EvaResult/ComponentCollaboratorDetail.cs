namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentCollaboratorDetail : BaseModel<int>
    {
        public string ComponentCollaboratorId { get; set; } = string.Empty;
        public string SubcomponentName { get; set; }
        public decimal WeightRelative { get; set; }
        public decimal PercentMinimun { get; set; }
        public decimal PercentMaximun { get; set; }
        public decimal Result { get; set; } 
        public decimal ResultCalibrated { get; set; } 
        public decimal ResultSimil { get; set; } 
        public int PointsTotalCalibrated { get; set; }


        public ComponentCollaborator ComponentCollaborator { get; set; }
    }
}
