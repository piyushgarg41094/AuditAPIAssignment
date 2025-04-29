using AuditTrail.Enums;
using AuditTrail.Models;

namespace AuditTrail.Services
{
    public class AuditService : IAuditService
    {
        public AuditEntry GenerateAuditLog(object before, object after, string userId, string entityName, AuditActionEnum action)
        {
            var entry = new AuditEntry
            {
                Action = action,
                EntityName = entityName,
                Timestamp = DateTime.UtcNow,
                UserId = userId
            };

            if (action == AuditActionEnum.Updated && before != null && after != null)
            {
                var type = before.GetType();
                foreach (var prop in type.GetProperties())
                {
                    var beforeValue = prop.GetValue(before)?.ToString();
                    var afterValue = prop.GetValue(after)?.ToString();
                    if (beforeValue != afterValue)
                    {
                        entry.Changes.Add(new AuditChange
                        {
                            PropertyName = prop.Name,
                            OldValue = beforeValue,
                            NewValue = afterValue
                        });
                    }
                }
            }
            else if (action == AuditActionEnum.Created && after != null)
            {
                foreach (var prop in after.GetType().GetProperties())
                {
                    var newValue = prop.GetValue(after)?.ToString();
                    entry.Changes.Add(new AuditChange
                    {
                        PropertyName = prop.Name,
                        OldValue = null,
                        NewValue = newValue
                    });
                }
            }
            else if (action == AuditActionEnum.Deleted && before != null)
            {
                foreach (var prop in before.GetType().GetProperties())
                {
                    var oldValue = prop.GetValue(before)?.ToString();
                    entry.Changes.Add(new AuditChange
                    {
                        PropertyName = prop.Name,
                        OldValue = oldValue,
                        NewValue = null
                    });
                }
            }

            return entry;
        }
    }

}
