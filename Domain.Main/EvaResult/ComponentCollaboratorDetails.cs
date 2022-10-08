namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentCollaboratorDetails : BaseModel<int>
    {
        public int IdComponentCollaborator { get; set; }
        public int IdComponentSubComponent { get; set; }
        public int WeightRelative { get; set; }
        public int PercentMinimun { get; set; }
        public int PercentMaximun { get; set; }
        public string Result { get; set; } = string.Empty;
        public string ResultCalibrated { get; set; } = string.Empty;
        public string ResultSimil { get; set; } = string.Empty;
        public int Points { get; set; }
        public int PointsTotalCalibrated { get; set; }


        public ComponentCollaborator? ComponentCollaborator { get; set; }
        /* 
         * TODO: EN EL MER ESTA TABLA SE RELACIONA CON LA TABLA ComponentSubComponent
         * pero esta tabla no existe, de momento la relacioné con SubComponent
        */
        public Subcomponent? SubComponent { get; set; }
    }
}
