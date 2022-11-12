﻿namespace Domain.Main.Config
{
    public class ParameterValue : BaseModel<int>
    {
        public Guid RangeParameterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string NameProperty { get; set; } = string.Empty;




        public RangeParameter RangeParameter { get; set; }
    }
}