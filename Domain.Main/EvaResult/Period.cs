namespace Domain.Main.EvaResult
{
    public class Period : BaseModel<int>
    {
        public Period()
        {
            Evaluations = new HashSet<Evaluation>();
        }

        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }





        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
