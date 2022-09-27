
namespace Domain.Main.Audit
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using SharedKernell.Helpers;
    using System.Text.Json;
    public class AuditEntry 
    {
        public AuditEntry(EntityEntry entityEntry)
        {
            EntityEntry = entityEntry;
        }

        public EntityEntry EntityEntry { get; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();
        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditEntity MapAudit(string user)
        {
            var auditEntry = new AuditEntity
            {
                TableName = TableName,
                CreateDate = DateTime.Now.GetDatePeru(),
                KeyValues = JsonSerializer.Serialize(KeyValues),
                OldValues = !OldValues.Any() ? "" : JsonSerializer.Serialize(OldValues),
                NewValues = !NewValues.Any() ? "" : JsonSerializer.Serialize(NewValues),
                CreateUser = user
            };

            return auditEntry;
        }
    }
}
