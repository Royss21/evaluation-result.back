using Domain.Main.EvaResult;

namespace Domain.Main.Config
{
    public class Component : BaseModel<int>
    {
        public Component()
        {
            HierarchyComponents = new HashSet<HierarchyComponent>();
            Subcomponents = new HashSet<Subcomponent>();
            EvaluationComponents = new HashSet<EvaluationComponent>();
        }
        public string Name { get; set; } = string.Empty;





        public virtual ICollection<HierarchyComponent> HierarchyComponents { get; set; }
        public virtual ICollection<Subcomponent> Subcomponents { get; set; }
        public virtual ICollection<EvaluationComponent> EvaluationComponents { get; set; }
    }
}
