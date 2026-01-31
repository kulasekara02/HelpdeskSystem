# Helpdesk Ticket System + Analytics Dashboard

A comprehensive helpdesk solution built with .NET 8, Blazor Server, and Oracle 19c database using Clean Architecture.

## Features

- **Ticket Management**: Create, update, delete, and track support tickets
- **Comments System**: Add comments to tickets for collaboration
- **Status History**: Track all status changes with timestamps
- **Role-Based Access**: Admin, Agent, and User roles
- **Analytics Dashboard**: Visual charts and KPI metrics
- **Search & Filters**: Filter by status, priority, date range, and agent
- **Agent Assignment**: Assign tickets to support agents

## Tech Stack

- **.NET 8** - Latest LTS version
- **ASP.NET Core Blazor Server** - Interactive UI
- **Minimal Web API** - Clean API endpoints
- **Entity Framework Core** - ORM for CRUD operations
- **Dapper** - For optimized report queries
- **Oracle 19c** - Database
- **ASP.NET Core Identity** - Authentication & Authorization
- **Chart.js** - Dashboard visualizations
- **Bootstrap 5** - UI styling
- **Serilog** - Logging
- **FluentValidation** - Input validation
- **AutoMapper** - Object mapping

## Project Structure (Clean Architecture)

```
HelpdeskSystem/
├── src/
│   ├── HelpdeskSystem.Domain/         # Entities, Enums
│   ├── HelpdeskSystem.Application/    # DTOs, Services, Interfaces, Validators
│   ├── HelpdeskSystem.Infrastructure/ # DbContext, Repositories, Oracle config
│   └── HelpdeskSystem.Web/            # Blazor UI, API endpoints, Auth
└── database/
    ├── create_tables.sql              # Oracle table creation script
    └── seed_data.sql                  # Sample data script
```

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Oracle 19c Database (or Oracle Cloud Free Tier)
- Visual Studio 2022 / VS Code / Rider

## How to Run

### Step 1: Clone or Download the Project

```bash
cd C:\Users\kule9\OneDrive\Desktop\HelpdeskSystem
```

### Step 2: Configure Database Connection

1. Open `src/HelpdeskSystem.Web/appsettings.json`
2. Replace `[PUT_PASSWORD_HERE]` with your actual Oracle password

**Recommended: Use User Secrets (for development)**

```bash
cd src/HelpdeskSystem.Web
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:OracleConnection" "Data Source=db.freesql.com:1521/19c_fy05s;User Id=PATHIRANAGE02_SCHEMA_3O65G;Password=YOUR_ACTUAL_PASSWORD;"
```

### Step 3: Restore NuGet Packages

```bash
dotnet restore
```

### Step 4: Create Database Migrations

```bash
cd src/HelpdeskSystem.Web
dotnet ef migrations add InitialCreate --project ../HelpdeskSystem.Infrastructure
```

### Step 5: Apply Migrations to Database

```bash
dotnet ef database update --project ../HelpdeskSystem.Infrastructure
```

### Step 6: Run the Application

```bash
dotnet run
```

Or run with hot reload:
```bash
dotnet watch run
```

### Step 7: Access the Application

Open your browser and navigate to:
- **HTTPS**: https://localhost:7001
- **HTTP**: http://localhost:5001

## Default Test Accounts

| Role  | Email                  | Password   |
|-------|------------------------|------------|
| Admin | admin@helpdesk.com     | Admin123!  |
| Agent | agent1@helpdesk.com    | Agent123!  |
| Agent | agent2@helpdesk.com    | Agent123!  |
| Agent | agent3@helpdesk.com    | Agent123!  |
| Agent | agent4@helpdesk.com    | Agent123!  |
| Agent | agent5@helpdesk.com    | Agent123!  |
| User  | user1@example.com      | User123!   |
| User  | user2@example.com      | User123!   |
| User  | user3@example.com      | User123!   |
| User  | user4@example.com      | User123!   |
| User  | user5@example.com      | User123!   |

## Role Permissions

| Feature                | Admin | Agent | User |
|------------------------|-------|-------|------|
| View Dashboard         | Yes   | Yes   | Yes  |
| Create Tickets         | Yes   | Yes   | Yes  |
| View All Tickets       | Yes   | Yes   | No*  |
| Edit Any Ticket        | Yes   | Yes   | No*  |
| Delete Tickets         | Yes   | No    | No   |
| Assign Agents          | Yes   | Yes   | No   |
| Manage Users           | Yes   | No    | No   |
| Update User Roles      | Yes   | No    | No   |

*Users can only view and edit their own tickets

## Oracle SQL Scripts

### Create Tables Manually (Optional)

If you prefer to create tables directly in Oracle:

```bash
sqlplus PATHIRANAGE02_SCHEMA_3O65G/password@db.freesql.com:1521/19c_fy05s @database/create_tables.sql
```

### Seed Data Manually (Optional)

Note: The application seeds data automatically on first run. Use this only if you need to insert data directly:

```bash
sqlplus PATHIRANAGE02_SCHEMA_3O65G/password@db.freesql.com:1521/19c_fy05s @database/seed_data.sql
```

## NuGet Packages

### Domain Layer
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.0)

### Application Layer
- AutoMapper (13.0.1)
- FluentValidation (11.9.0)
- FluentValidation.DependencyInjectionExtensions (11.9.0)

### Infrastructure Layer
- Oracle.EntityFrameworkCore (8.21.121)
- Oracle.ManagedDataAccess.Core (23.4.0)
- Microsoft.EntityFrameworkCore (8.0.0)
- Microsoft.EntityFrameworkCore.Design (8.0.0)
- Dapper (2.1.28)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.0)

### Web Layer
- FluentValidation.AspNetCore (11.3.0)
- Microsoft.AspNetCore.Components.QuickGrid (8.0.0)
- Serilog.AspNetCore (8.0.0)
- Serilog.Sinks.Console (5.0.1)
- Serilog.Sinks.File (5.0.0)

## API Endpoints

### Tickets
- `GET /api/tickets` - Get all tickets (with filters)
- `GET /api/tickets/{id}` - Get ticket by ID
- `POST /api/tickets` - Create new ticket
- `PUT /api/tickets/{id}` - Update ticket
- `DELETE /api/tickets/{id}` - Delete ticket (Admin only)
- `POST /api/tickets/{id}/assign` - Assign agent (Admin/Agent)
- `GET /api/tickets/my-tickets` - Get current user's tickets
- `GET /api/tickets/assigned` - Get assigned tickets (Agent)

### Comments
- `GET /api/comments/ticket/{ticketId}` - Get comments for ticket
- `POST /api/comments` - Add comment
- `DELETE /api/comments/{id}` - Delete comment

### Dashboard
- `GET /api/dashboard` - Get dashboard data
- `GET /api/dashboard/dapper` - Get dashboard with Dapper (Admin)
- `GET /api/dashboard/tickets-per-day` - Get tickets per day

### Users
- `GET /api/users` - Get all users (Admin)
- `GET /api/users/agents` - Get all agents
- `GET /api/users/{id}` - Get user by ID (Admin)
- `PUT /api/users/{id}/roles` - Update user roles (Admin)
- `DELETE /api/users/{id}` - Delete user (Admin)

## Troubleshooting

### Oracle Connection Issues

1. Verify your Oracle connection string format:
   ```
   Data Source=host:port/service_name;User Id=username;Password=password;
   ```

2. Check if Oracle client is installed or use managed driver (included)

3. Test connection with SQL*Plus:
   ```bash
   sqlplus username/password@host:port/service_name
   ```

### EF Core Migration Issues

If migrations fail, try:
```bash
dotnet ef database drop --force --project ../HelpdeskSystem.Infrastructure
dotnet ef migrations remove --project ../HelpdeskSystem.Infrastructure
dotnet ef migrations add InitialCreate --project ../HelpdeskSystem.Infrastructure
dotnet ef database update --project ../HelpdeskSystem.Infrastructure
```

### Reset Seed Data

Delete all data and re-seed:
```sql
DELETE FROM STATUSHISTORY;
DELETE FROM COMMENTS;
DELETE FROM TICKETS;
-- Restart the application to re-seed
```

## Environment Variables

For production, set these environment variables:

```bash
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__OracleConnection=your_production_connection_string
```

## Logs

Logs are written to:
- Console (Development)
- `logs/helpdesk-{date}.log` (File)

## License

MIT License - Feel free to use this project for learning and development.

## Credits

Built with .NET 8 and Oracle 19c for demonstrating Clean Architecture patterns.
