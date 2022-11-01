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
        }

        public Guid EvaluationId { get; set; }
        public Guid CollaboratorId { get; set; }
        public int GerencyId { get; set; }
        public int ChargeId { get; set; }
        public int AreaId { get; set; }
        public int HierarchyId { get; set; }
        public int LevelId { get; set; }





        public virtual Evaluation Evaluation { get; set; }
        public virtual Collaborator Collaborator { get; set; }
        public virtual Gerency Gerency { get; set; }
        public virtual Charge Charge { get; set; }
        public virtual Area Area { get; set; }
        public virtual Hierarchy Hierarchy { get; set; }
        public virtual Level Level { get; set; }
        public virtual EvaluationLeader EvaluationLeader { get; set; }
        public virtual ICollection<ComponentCollaborator> ComponentsCollaborator { get; set; }
        public virtual ICollection<LeaderCollaborator> LeaderCollaborators { get; set; }
    }
}
