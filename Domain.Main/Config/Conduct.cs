namespace Domain.Main.Config
{
    public class Conduct : BaseModelActive<string>
    {
        public int LevelId { get; set; }
        public string SubcomponentId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Level Level { get; set; }
        public Subcomponent Subcomponent { get; set; }
    }
}
