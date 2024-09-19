using Backend.Application.DTOs;
using Backend.Application.DTOs.Logs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces.Repositories
{
    public interface ILogRepository
    {
        Task<List<AuditLogResponse>> GetAuditLogsAsync(string userId);

        Task AddLogAsync(string action, string userId);
    }
}