using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskSystem.Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<List<UserWithRolesDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userManager.Users
            .Include(u => u.AssignedTickets)
            .ToListAsync(cancellationToken);

        var userDtos = new List<UserWithRolesDto>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userDtos.Add(new UserWithRolesDto
            {
                Id = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                FullName = user.FullName,
                CreatedAt = user.CreatedAt,
                Roles = roles.ToList(),
                AssignedTicketsCount = user.AssignedTickets.Count
            });
        }

        return userDtos;
    }

    public async Task<List<UserDto>> GetAgentsAsync(CancellationToken cancellationToken = default)
    {
        var agentRole = await _roleManager.FindByNameAsync("Agent");
        if (agentRole == null) return new List<UserDto>();

        var users = await _userManager.GetUsersInRoleAsync("Agent");

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            UserName = u.UserName ?? string.Empty,
            Email = u.Email ?? string.Empty,
            FullName = u.FullName,
            CreatedAt = u.CreatedAt,
            Roles = new List<string> { "Agent" }
        }).ToList();
    }

    public async Task<UserDto?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return null;

        var roles = await _userManager.GetRolesAsync(user);

        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            FullName = user.FullName,
            CreatedAt = user.CreatedAt,
            Roles = roles.ToList()
        };
    }

    public async Task<bool> UpdateUserRolesAsync(UpdateUserRolesDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId);
        if (user == null) return false;

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRolesAsync(user, dto.Roles);

        return true;
    }

    public async Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return false;

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}
