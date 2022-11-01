namespace Domain.Main.EvaResult
{
    using Domain.Main.Employee;


    public class EvaluationLeader : BaseModel<int>
    {
        public EvaluationLeader()
        {
            LeaderStages = new HashSet<LeaderStage>();
        }

        public Guid EvaluationCollaboratorId { get; set; }
        public int? AreaId { get; set; }
        public Guid EvaluationId { get; set; }





        public virtual EvaluationCollaborator EvaluationCollaborator { get; set; }
        public virtual Evaluation Evaluation { get; set; }
        public virtual Area? Area { get; set; }
        public virtual ICollection<LeaderStage> LeaderStages { get; set; }
    }
}
