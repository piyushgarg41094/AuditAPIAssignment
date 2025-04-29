using AuditTrail.Enums;
using AuditTrail.Models;

namespace AuditTrail.Services
{
    public interface IAuditService
    {
        AuditEntry GenerateAuditLog(object before, object after, string userId, string entityName, AuditActionEnum action);
    }
}
