
namespace Domain.Main.Collaborator
{
    using Domain.Main.Config;
    public class Hierarchy : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;
        public int IdLevel { get; set; }

        public Level? Level { get; set; }
    }
}
