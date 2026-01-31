using HelpdeskSystem.Application.DTOs;

namespace HelpdeskSystem.Application.Interfaces;

public interface IUserService
{
    Task<List<UserWithRolesDto>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<List<UserDto>> GetAgentsAsync(CancellationToken cancellationToken = default);
    Task<UserDto?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> UpdateUserRolesAsync(UpdateUserRolesDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteUserAsync(string id, CancellationToken cancellationToken = default);
}
