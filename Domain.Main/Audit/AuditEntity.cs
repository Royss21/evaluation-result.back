﻿
namespace Domain.Main.Audit
{
    public class AuditEntity : BaseModel<int>
    {
        public string TableName { get; set; } = string.Empty;
        public string KeyValues { get; set; } = string.Empty;
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;
    }
}
