namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;


    public class LeaderStage : BaseModel<int>
    {
        public LeaderStage()
        {
            LeaderCollaborators = new HashSet<LeaderCollaborator>();
        }

        public int EvaluationLeaderId { get; set; }
        public int StageId { get; set; }





        public virtual EvaluationLeader EvaluationLeader { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual ICollection<LeaderCollaborator> LeaderCollaborators { get; set; }
    }
}
