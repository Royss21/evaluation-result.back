namespace Domain.Main.Security
{
    public class Role : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
