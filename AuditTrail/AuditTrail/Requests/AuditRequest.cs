using AuditTrail.Enums;

namespace AuditTrail.Requests
{
    public class AuditRequest
    {
        public object Before { get; set; }
        public object After { get; set; }
        public string UserId { get; set; }
        public string EntityName { get; set; }
        public AuditActionEnum Action { get; set; }
    }

}
