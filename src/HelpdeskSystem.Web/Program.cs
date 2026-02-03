using FluentValidation;
using FluentValidation.AspNetCore;
using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Application.Mappings;
using HelpdeskSystem.Application.Services;
using HelpdeskSystem.Application.Validators;
using HelpdeskSystem.Domain.Entities;
using HelpdeskSystem.Infrastructure.Data;
using HelpdeskSystem.Infrastructure.Data.Seed;
using HelpdeskSystem.Infrastructure.Repositories;
using HelpdeskSystem.Infrastructure.Reports;
using HelpdeskSystem.Web.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure SQLite Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Configure cookie authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(24);
    options.SlidingExpiration = true;
});

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTicketValidator>();

// Register application services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDapperReportService, DapperReportService>();

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("AgentOrAdmin", policy => policy.RequireRole("Admin", "Agent"));
    options.AddPolicy("AuthenticatedUser", policy => policy.RequireAuthenticatedUser());
});

// Add HttpContextAccessor for Blazor
builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        await DataSeeder.SeedAsync(services);
        Log.Information("Database migration and seeding completed successfully");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred while migrating or seeding the database");
    }
}

Log.Information("Helpdesk System starting up...");
app.Run();
