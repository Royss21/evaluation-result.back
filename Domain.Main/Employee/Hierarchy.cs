
namespace Domain.Main.Employee
{
    using Domain.Main.Config;
    using Domain.Main.EvaResult;

    public class Hierarchy : BaseModel<int>
    {
        public Hierarchy()
        {
            HierarchyComponents = new HashSet<HierarchyComponent>();
            EvaluationCollaborators = new HashSet<EvaluationCollaborator>();
            Charges = new HashSet<Charge>();
        }

        public int LevelId { get; set; }
        public string Name { get; set; } = string.Empty;





        public virtual Level Level { get; set; }
        public virtual ICollection<Charge> Charges { get; set; }
        public virtual ICollection<HierarchyComponent> HierarchyComponents { get; set; }
        public virtual ICollection<EvaluationCollaborator> EvaluationCollaborators { get; set; }
    }
}
