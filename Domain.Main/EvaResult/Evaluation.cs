﻿namespace Domain.Main.EvaResult
{
    public class Evaluation : BaseModel<Guid>
    {
        public Evaluation()
        {
            EvaluationCollaborators = new HashSet<EvaluationCollaborator>();
            EvaluationComponents = new HashSet<EvaluationComponent>();
            EvaluationLeaders = new HashSet<EvaluationLeader>();
            EvaluationStages = new HashSet<EvaluationStage>();
        }

        public int PeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Weight { get; set; }
        public int StatusId { get; set; }





        public virtual Period Period { get; set; }
        public virtual ICollection<EvaluationCollaborator> EvaluationCollaborators { get; set; }
        public virtual ICollection<EvaluationComponent> EvaluationComponents { get; set; }
        public virtual ICollection<EvaluationLeader> EvaluationLeaders { get; set; }
        public virtual ICollection<EvaluationStage> EvaluationStages { get; set; }

    }
}
