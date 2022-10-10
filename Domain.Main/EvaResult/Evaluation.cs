namespace Domain.Main.EvaResult
{
    public class Evaluation : BaseModel<string>
    {
        public int IdPeriod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Weight { get; set; } 

        public Period Period { get; set; }
    }
}
