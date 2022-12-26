using Domain.Main.Config;

namespace Domain.Main.EvaResult
{
    public class Evaluation : BaseModel<Guid>
    {
        public Evaluation()
        {
            EvaluationCollaborators = new HashSet<EvaluationCollaborator>();
            EvaluationComponents = new HashSet<EvaluationComponent>();
            EvaluationLeaders = new HashSet<EvaluationLeader>();
            EvaluationComponentStages = new HashSet<EvaluationComponentStage>();
        }

        
        public int PeriodId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Weight { get; set; }
        public int StatusId { get; set; }




        public virtual Status Status { get; set; }
        public virtual Period Period { get; set; }
        public virtual ICollection<EvaluationCollaborator> EvaluationCollaborators { get; set; }
        public virtual ICollection<EvaluationComponent> EvaluationComponents { get; set; }
        public virtual ICollection<EvaluationLeader> EvaluationLeaders { get; set; }
        public virtual ICollection<EvaluationComponentStage> EvaluationComponentStages { get; set; }

    }
}
