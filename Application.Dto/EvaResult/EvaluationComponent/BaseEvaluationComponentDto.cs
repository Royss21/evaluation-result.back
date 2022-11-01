namespace Application.Dto.EvaResult.EvaluationComponent
{
    public abstract class BaseEvaluationComponentDto
    {
        public string EvaluationId { get; set; } = string.Empty;
        public int ComponentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

/*
 profe sigue los cortes :C, o capaz mi inter de 2mb es el tema xD
 */
