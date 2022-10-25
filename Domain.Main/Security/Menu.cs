namespace Domain.Main.Security
{
    public class Menu : BaseModelActive<int>
    {

        public int? MenuId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Sort { get; set; }

        public Menu? MenuDad { get; set; }
    }
}