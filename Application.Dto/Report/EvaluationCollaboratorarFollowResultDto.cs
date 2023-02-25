
namespace Application.Dto.Report
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    public class EvaluationCollaboratorarFollowResultDto : CollaboratorInformationDto
    {
        public Guid EvaluationCollaboratorId { get; set; }
        public Guid EvaluationId { get; set; }
        public decimal ResultObjectiveCorporate { get; set; }
        public decimal ResultObjectiveArea { get; set; }
        public decimal ResultCompetence { get; set; }
        public int StatusObjectiveCorporateId { get; set; }
        public int StatusObjectiveAreaId { get; set; }
        public int StatusCompetenceId { get; set; }
        public int StageCurrentId { get; set; }
    }
}
