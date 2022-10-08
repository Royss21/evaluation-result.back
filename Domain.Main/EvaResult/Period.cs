namespace Domain.Main.EvaResult
{
    public class Period : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;
        public string DateStart { get; set; } = string.Empty;
        public string DateEnd { get; set; } = string.Empty;
    }
}
