
namespace Application.Dto.EvaResult.EvaluationLeader
{
    using Domain.Common.Enums;
    using Microsoft.AspNetCore.Http;
    public class EvaluationLeaderFileDto
    {
        public IFormFile File { get; set; }
        public Guid EvaluationId { get; set; }
        public bool IsToReprocess { get; set; }
        public TypeImportLeadersEnum TypeImportLeaders { get; set; }

        public List<EvaluationLeaderFileDataDto> EvaluationLeaderFileDataDto { get; set; }
    }

}
