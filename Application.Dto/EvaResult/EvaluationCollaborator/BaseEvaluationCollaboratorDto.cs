namespace Application.Dto.EvaResult.EvaluationCollaborator
{
    public abstract class BaseEvaluationCollaboratorDto
    {
        public Guid EvaluationId { get; set; }
        public Guid CollaboratorId { get; set; }
        public int GerencyId { get; set; }
        public int ChargeId { get; set; }
        public int AreaId { get; set; }
        public int HierarchyId { get; set; }
        public int LevelId { get; set; }
    }
}
