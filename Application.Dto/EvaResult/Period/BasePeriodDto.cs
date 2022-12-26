namespace Application.Dto.EvaResult.Period
{
    public abstract class BasePeriodDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
