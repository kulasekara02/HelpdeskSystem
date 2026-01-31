using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Infrastructure.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpdeskSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;
    private readonly IDapperReportService _reportService;

    public DashboardController(IDashboardService dashboardService, IDapperReportService reportService)
    {
        _dashboardService = dashboardService;
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<ActionResult<DashboardDto>> GetDashboard()
    {
        var dashboard = await _dashboardService.GetDashboardDataAsync();
        return Ok(dashboard);
    }

    [HttpGet("dapper")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<DashboardDto>> GetDashboardWithDapper()
    {
        // This uses Dapper for complex reports
        var dashboard = await _reportService.GetDashboardDataAsync();
        return Ok(dashboard);
    }

    [HttpGet("tickets-per-day")]
    public async Task<ActionResult<List<TicketsPerDayDto>>> GetTicketsPerDay([FromQuery] int days = 14)
    {
        var data = await _reportService.GetTicketsPerDayAsync(days);
        return Ok(data);
    }
}
