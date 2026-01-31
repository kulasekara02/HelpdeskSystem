using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Application.Services;
using HelpdeskSystem.Infrastructure.Repositories;
using HelpdeskSystem.Infrastructure.Reports;

namespace HelpdeskSystem.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Register application services
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IUserService, UserService>();

        // Register Dapper report service
        services.AddScoped<IDapperReportService, DapperReportService>();

        return services;
    }
}
