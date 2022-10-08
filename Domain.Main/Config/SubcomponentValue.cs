﻿
namespace Domain.Main.Config
{
    using Domain.Main.Collaborator;
    public class SubcomponentValue : BaseModel<string>
    {
        public string IdSubcomponent { get; set; } = string.Empty;
        public int IdCargo { get; set; }
        public decimal RelativeWeight { get; set; }
        public decimal MinimunPercentage { get; set; }
        public decimal MaximunPercentage { get; set; }


        public Subcomponent? Subcomponent { get; set; }
        public Charge? Charge { get; set; }
    }
}
