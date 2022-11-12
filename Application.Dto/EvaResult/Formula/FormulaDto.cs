
namespace Application.Dto.EvaResult.Formula
{
    using System.Text.Json.Serialization;
    public class FormulaDto : BaseFormulaDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
