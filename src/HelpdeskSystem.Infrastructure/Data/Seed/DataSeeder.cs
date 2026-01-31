using HelpdeskSystem.Domain.Entities;
using HelpdeskSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HelpdeskSystem.Infrastructure.Data.Seed;

public static class DataSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        // Seed roles
        await SeedRolesAsync(roleManager);

        // Seed users
        var users = await SeedUsersAsync(userManager);

        // Seed tickets if none exist
        if (!context.Tickets.Any())
        {
            await SeedTicketsAsync(context, users);
        }
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = { "Admin", "Agent", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task<Dictionary<string, ApplicationUser>> SeedUsersAsync(UserManager<ApplicationUser> userManager)
    {
        var users = new Dictionary<string, ApplicationUser>();

        // Admin user
        var admin = await CreateUserIfNotExistsAsync(userManager, new ApplicationUser
        {
            UserName = "admin@helpdesk.com",
            Email = "admin@helpdesk.com",
            FullName = "System Administrator",
            EmailConfirmed = true,
            CreatedAt = DateTime.UtcNow.AddDays(-30)
        }, "Admin123!", "Admin");
        if (admin != null) users["admin"] = admin;

        // Agent users (5 agents)
        var agentNames = new[] {
            ("agent1@helpdesk.com", "John Smith"),
            ("agent2@helpdesk.com", "Sarah Johnson"),
            ("agent3@helpdesk.com", "Mike Wilson"),
            ("agent4@helpdesk.com", "Emily Davis"),
            ("agent5@helpdesk.com", "Robert Brown")
        };

        for (int i = 0; i < agentNames.Length; i++)
        {
            var agent = await CreateUserIfNotExistsAsync(userManager, new ApplicationUser
            {
                UserName = agentNames[i].Item1,
                Email = agentNames[i].Item1,
                FullName = agentNames[i].Item2,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow.AddDays(-25 + i)
            }, "Agent123!", "Agent");
            if (agent != null) users[$"agent{i + 1}"] = agent;
        }

        // Regular users (5 users)
        var userNames = new[] {
            ("user1@example.com", "Alice Cooper"),
            ("user2@example.com", "Bob Martin"),
            ("user3@example.com", "Charlie Evans"),
            ("user4@example.com", "Diana Ross"),
            ("user5@example.com", "Edward King")
        };

        for (int i = 0; i < userNames.Length; i++)
        {
            var user = await CreateUserIfNotExistsAsync(userManager, new ApplicationUser
            {
                UserName = userNames[i].Item1,
                Email = userNames[i].Item1,
                FullName = userNames[i].Item2,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow.AddDays(-20 + i)
            }, "User123!", "User");
            if (user != null) users[$"user{i + 1}"] = user;
        }

        return users;
    }

    private static async Task<ApplicationUser?> CreateUserIfNotExistsAsync(
        UserManager<ApplicationUser> userManager,
        ApplicationUser user,
        string password,
        string role)
    {
        var existingUser = await userManager.FindByEmailAsync(user.Email!);
        if (existingUser != null) return existingUser;

        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, role);
            return user;
        }
        return null;
    }

    private static async Task SeedTicketsAsync(ApplicationDbContext context, Dictionary<string, ApplicationUser> users)
    {
        var random = new Random(42); // Fixed seed for reproducible data
        var tickets = new List<Ticket>();
        var comments = new List<Comment>();
        var statusHistories = new List<StatusHistory>();

        var ticketTitles = new[]
        {
            "Cannot login to the system",
            "Email not syncing properly",
            "Password reset not working",
            "Application crashes on startup",
            "Need access to shared drive",
            "Printer not responding",
            "VPN connection issues",
            "Software installation request",
            "Slow computer performance",
            "Monitor display flickering",
            "Keyboard not functioning",
            "Mouse scroll not working",
            "File recovery needed",
            "Network connectivity problem",
            "Browser keeps freezing",
            "Audio not working in meetings",
            "Webcam quality issues",
            "System update failure",
            "Database connection error",
            "Report generation taking too long"
        };

        var descriptions = new[]
        {
            "I've been experiencing this issue for the past few days. I've tried restarting but it doesn't help.",
            "This started happening after the last update. Please investigate as it's affecting my work.",
            "Urgent: Need this resolved ASAP as it's blocking my daily tasks.",
            "The error message shows 'connection timeout'. I've attached screenshots for reference.",
            "Multiple team members are experiencing this issue. Seems to be a widespread problem.",
            "Tried the troubleshooting steps from the knowledge base but still facing the issue.",
            "This is intermittent but happens frequently enough to be disruptive.",
            "First time user here, not sure if I'm doing something wrong.",
            "This was working fine yesterday but stopped working today morning.",
            "Critical issue affecting production work. Please prioritize."
        };

        var commentTexts = new[]
        {
            "Thank you for reporting this issue. We are looking into it.",
            "Can you please provide more details about when this started?",
            "I've escalated this to the technical team.",
            "We've identified the root cause and are working on a fix.",
            "Could you try clearing your cache and cookies?",
            "This is a known issue. A patch will be released soon.",
            "I've tested this on my end and couldn't reproduce the issue.",
            "Please try the steps mentioned in our FAQ section.",
            "The fix has been deployed. Please verify if the issue is resolved.",
            "Closing this ticket as the issue has been resolved.",
            "Thank you for your patience while we worked on this.",
            "I've updated the ticket status. Please let us know if you need anything else.",
            "We need to schedule a remote session to diagnose this further.",
            "The issue was caused by a configuration error. It's been fixed now.",
            "Please update your software to the latest version and try again."
        };

        var userKeys = users.Keys.Where(k => k.StartsWith("user")).ToList();
        var agentKeys = users.Keys.Where(k => k.StartsWith("agent")).ToList();

        for (int i = 0; i < 20; i++)
        {
            var createdDaysAgo = random.Next(1, 15);
            var createdAt = DateTime.UtcNow.AddDays(-createdDaysAgo).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60));
            var userKey = userKeys[random.Next(userKeys.Count)];
            var agentKey = random.Next(10) > 2 ? agentKeys[random.Next(agentKeys.Count)] : null;
            var status = (TicketStatus)random.Next(4);
            var priority = (TicketPriority)random.Next(3);

            var ticket = new Ticket
            {
                Id = Guid.NewGuid().ToString(),
                Title = ticketTitles[i],
                Description = descriptions[random.Next(descriptions.Length)],
                Priority = priority,
                Status = status,
                CreatedAt = createdAt,
                UpdatedAt = status != TicketStatus.Open ? createdAt.AddHours(random.Next(1, 48)) : null,
                CreatedByUserId = users[userKey].Id,
                AssignedAgentId = agentKey != null ? users[agentKey].Id : null
            };

            tickets.Add(ticket);

            // Add initial status history
            statusHistories.Add(new StatusHistory
            {
                Id = Guid.NewGuid().ToString(),
                TicketId = ticket.Id,
                OldStatus = null,
                NewStatus = TicketStatus.Open,
                ChangedAt = createdAt,
                ChangedByUserId = users[userKey].Id
            });

            // Add status change history if status is not Open
            if (status != TicketStatus.Open)
            {
                var changerKey = agentKey ?? "admin";
                statusHistories.Add(new StatusHistory
                {
                    Id = Guid.NewGuid().ToString(),
                    TicketId = ticket.Id,
                    OldStatus = TicketStatus.Open,
                    NewStatus = status,
                    ChangedAt = ticket.UpdatedAt ?? createdAt.AddHours(1),
                    ChangedByUserId = users[changerKey].Id
                });
            }

            // Add 1-3 comments per ticket
            var commentCount = random.Next(1, 4);
            for (int j = 0; j < commentCount; j++)
            {
                var commenterKey = j % 2 == 0 && agentKey != null ? agentKey : userKey;
                comments.Add(new Comment
                {
                    Id = Guid.NewGuid().ToString(),
                    TicketId = ticket.Id,
                    Text = commentTexts[random.Next(commentTexts.Length)],
                    CreatedAt = createdAt.AddHours(random.Next(1, 24) + j * 2),
                    CreatedByUserId = users[commenterKey].Id
                });
            }
        }

        await context.Tickets.AddRangeAsync(tickets);
        await context.Comments.AddRangeAsync(comments);
        await context.StatusHistories.AddRangeAsync(statusHistories);
        await context.SaveChangesAsync();
    }
}
