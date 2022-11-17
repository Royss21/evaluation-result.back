namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;
    using  Domain.Main.Employee;

    public class EvaluationCollaborator : BaseModel<Guid>
    {
        public EvaluationCollaborator()
        {
            ComponentsCollaborator = new HashSet<ComponentCollaborator>();
            LeaderCollaborators = new HashSet<LeaderCollaborator>();
            ComponentCollaboratorComments = new HashSet<ComponentCollaboratorComment>();
            EvaluationLeaders = new HashSet<EvaluationLeader>();
        }

        public Guid EvaluationId { get; set; }
        public Guid CollaboratorId { get; set; }
        public string GerencyName { get; set; } = string.Empty;
        public string ChargeName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;





        public virtual Evaluation Evaluation { get; set; }
        public virtual Collaborator Collaborator { get; set; }
        public virtual ICollection<EvaluationLeader> EvaluationLeaders { get; set; }
        public virtual ICollection<ComponentCollaborator> ComponentsCollaborator { get; set; }
        public virtual ICollection<LeaderCollaborator> LeaderCollaborators { get; set; }
        public virtual ICollection<ComponentCollaboratorComment> ComponentCollaboratorComments { get; set; }
    }
}
