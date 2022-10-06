
namespace Domain.Main.Config
{
    using Domain.Main.Collaborator;

    public class Subcomponent : BaseModel<string>
    {
        public int IdComponent { get; set; }
        public int IdArea { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public Component Component { get; set; }
        public Area Area { get; set; }
    }
}
