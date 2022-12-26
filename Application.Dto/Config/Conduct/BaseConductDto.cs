namespace Application.Dto.Config.Conduct
{
    public abstract class BaseConductDto
    {
        public int LevelId { get; set; }
        public Guid SubcomponentId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
