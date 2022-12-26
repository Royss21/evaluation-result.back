namespace Domain.Main.Config
{
    public class Conduct : BaseModelActive<Guid>
    {
        public int LevelId { get; set; }
        public Guid SubcomponentId { get; set; }
        public string Description { get; set; } = string.Empty;





        public virtual Level Level { get; set; }
        public virtual Subcomponent Subcomponent { get; set; }
    }
}
