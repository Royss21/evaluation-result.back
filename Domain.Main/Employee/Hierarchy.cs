
namespace Domain.Main.Employee
{
    using Domain.Main.Config;
    public class Hierarchy : BaseModel<int>
    {
        public int LevelId { get; set; }
        public string Name { get; set; } = string.Empty;

        public Level Level { get; set; }
    }
}
