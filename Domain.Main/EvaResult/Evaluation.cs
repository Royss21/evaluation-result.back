namespace Domain.Main.EvaResult
{
    public class Evaluation : BaseModel<int>
    {
        public int IdPeriod { get; set; }
        public string DateStart { get; set; } = string.Empty;
        public string DateEnd { get; set; } = string.Empty;
        public int Weight { get; set; } 


        public Period? Period { get; set; }
    }
}
