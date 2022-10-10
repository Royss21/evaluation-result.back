﻿namespace Domain.Main.EvaResult
{
    public class Period : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
