namespace Application.Dto.Security.Menu
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int? MenuDadId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Sort { get; set; }
    }
}
