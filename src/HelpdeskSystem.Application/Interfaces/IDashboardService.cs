using HelpdeskSystem.Application.DTOs;

namespace HelpdeskSystem.Application.Interfaces;

public interface IDashboardService
{
    Task<DashboardDto> GetDashboardDataAsync(CancellationToken cancellationToken = default);
}
