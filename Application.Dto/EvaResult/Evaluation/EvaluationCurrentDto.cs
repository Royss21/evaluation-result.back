namespace Application.Dto.EvaResult.Evaluation
{
    public class EvaluationCurrentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasComponentCorporateObjectives { get; set; }
        public bool HasComponentAreaObjectives { get; set; }
        public bool HasComponentCompetencies { get; set; }
        public string RangeDate { get; set; } = string.Empty;
    }
}
