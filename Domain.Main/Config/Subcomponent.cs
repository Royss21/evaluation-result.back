
namespace Domain.Main.Config
{
    using Domain.Main.Employee;

    public class Subcomponent : BaseModel<string>
    {
        public int ComponentId { get; set; }
        public int? AreaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public Component Component { get; set; }
        public Area? Area { get; set; }
    }
}
