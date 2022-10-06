namespace Domain.Main.Config
{
    public class Level : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
