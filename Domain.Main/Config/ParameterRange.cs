namespace Domain.Main.Config
{
    public class ParameterRange : BaseModel<Guid>
    {
        public ParameterRange()
        {
            ParametersValue = new HashSet<ParameterValue>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsInternalConfiguration { get; set; }




        public virtual ICollection<ParameterValue> ParametersValue { get; set; }
    }
}
