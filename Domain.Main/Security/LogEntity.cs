namespace Domain.Main.Security
{
    public class LogEntity : BaseModel<int>
    {
        public string Message { get; set; } = string.Empty;
        public string InnerExceptionMessage { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public string FullNameService { get; set; } = string.Empty;
        public string TypeException { get; set; } = string.Empty;

    }
}
