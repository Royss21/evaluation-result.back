namespace Application.Dto.EvaResult.ComponentCollaborator
{
    public class UpdateStatusDto
    {
        public Guid? Id { get; set; }
        public int StatusId { get; set; }
        public int? EvaluationComponentStageId { get; set; }
        public Guid? EvaluationCollaboratorId { get; set; }
        public bool IsUpdateComponent { get; set; } = true;
    }
}
