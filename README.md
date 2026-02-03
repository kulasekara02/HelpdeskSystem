# Helpdesk Ticket System + Analytics Dashboard

A comprehensive helpdesk solution built with .NET 8, Blazor Server, and SQLite database using Clean Architecture principles.

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
- **SQLite** - Lightweight embedded database
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
- Visual Studio 2022 / VS Code / Rider (optional)
- No database installation required - SQLite is embedded!

## How to Run

### Step 1: Clone the Repository

```bash
git clone https://github.com/kulasekara02/HelpdeskSystem.git
cd HelpdeskSystem
```

### Step 2: Restore NuGet Packages

```bash
dotnet restore
```

### Step 3: Run the Application

```bash
cd src/HelpdeskSystem.Web
dotnet run
```

The database will be created automatically on first run!

```bash
dotnet run
```

Or run with hot reload:
```bash
dotnet watch run
```

### Step 4: Access the Application

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

## Database

The application uses SQLite as an embedded database. The database file (`helpdesk.db`) is created automatically in the `src/HelpdeskSystem.Web` directory on first run.

Migrations are already included and will be applied automatically.

## NuGet Packages

### Domain Layer
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.0)

### Application Layer
- AutoMapper (13.0.1)
- FluentValidation (11.9.0)
- FluentValidation.DependencyInjectionExtensions (11.9.0)

### Infrastructure Layer
- Microsoft.EntityFrameworkCore.Sqlite (8.0.0)
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

### Database Issues

If you encounter database issues, delete the database file and restart:
```bash
rm src/HelpdeskSystem.Web/helpdesk.db*
dotnet run
```

### Reset Database

To start with a fresh database:
```bash
cd src/HelpdeskSystem.Web
rm helpdesk.db*
dotnet ef database update --project ../HelpdeskSystem.Infrastructure
```

## Screenshots

_Add screenshots of your application here_

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Logs

Logs are written to:
- Console (Development)
- `logs/helpdesk-{date}.log` (File)

## License

MIT License - Feel free to use this project for learning and development.

## Credits

Built with .NET 8 and SQLite for demonstrating Clean Architecture patterns in a modern web application.

## Author

**kulasekara02**
- GitHub: [@kulasekara02](https://github.com/kulasekara02)
- Repository: [HelpdeskSystem](https://github.com/kulasekara02/HelpdeskSystem)
