namespace Application.Dto.EvaResult.EvaluationLeader
{
    public class LeaderCollaboratorsFilterDto
    {
        public string GlobalFilter { get; set; } = string.Empty;
        public string StageIds { get; set; } = string.Empty;
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public int ComponentId { get; set; }
    }
}
