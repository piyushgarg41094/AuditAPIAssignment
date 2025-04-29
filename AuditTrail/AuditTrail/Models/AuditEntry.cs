using AuditTrail.Enums;

namespace AuditTrail.Models
{
    public class AuditEntry
    {
        public string EntityName { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public AuditActionEnum Action { get; set; }
        public List<AuditChange> Changes { get; set; } = new();
    }
}
