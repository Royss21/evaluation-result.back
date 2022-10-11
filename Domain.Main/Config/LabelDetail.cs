﻿namespace Domain.Main.Config
{
    public class LabelDetail: BaseModel<int>
    {
        public int IdLabel { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal RealValue { get; set; }
        public decimal MinimunValue { get; set; }
        public decimal MaximunValue { get; set; }
        public string Icon { get; set; } = string.Empty;


        public Label Label { get; set; }
    }
}