using AuditTrail.Requests;
using AuditTrail.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuditTrail.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpPost]
        public IActionResult CreateAudit([FromBody] AuditRequest request)
        {
            var auditLog = _auditService.GenerateAuditLog(
                request.Before,
                request.After,
                request.UserId,
                request.EntityName,
                request.Action
            );
            return Ok(auditLog);
        }
    }

}
