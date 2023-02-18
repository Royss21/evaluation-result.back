namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentCollaboratorDetail : BaseModel<int>
    {
        public ComponentCollaboratorDetail()
        {
            ComponentCollaboratorConducts = new HashSet<ComponentCollaboratorConduct>();
        }

        public Guid ComponentCollaboratorId { get; set; }
        public string SubcomponentName { get; set; }
        public decimal WeightRelative { get; set; }
        public decimal MinimunPercentage { get; set; }
        public decimal MaximunPercentage { get; set; }
        public decimal Result { get; set; } 
        public decimal Compliance { get; set; }
        public decimal Points { get; set; }
        public decimal PointsCalibrated { get; set; }
        public string FormulaName { get; set; } = string.Empty;
        public string FormulaQuery { get; set; } = string.Empty;
        public string FormulaValues { get; set; } = string.Empty;





        public virtual ComponentCollaborator ComponentCollaborator { get; set; }
        public virtual ICollection<ComponentCollaboratorConduct> ComponentCollaboratorConducts { get; set; }
    }
}
