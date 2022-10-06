namespace Domain.Main.Config
{
    public class Conduct : BaseModelActive<string>
    {
        public int IdLevel { get; set; }
        public string IdSubcomponent { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
