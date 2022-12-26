namespace Domain.Main.Config
{
    public class Label: BaseModel<int>
    {
        public Label()
        {
            LabelDetails = new HashSet<LabelDetail>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;




        public virtual ICollection<LabelDetail> LabelDetails { get; set; }
    }
}
