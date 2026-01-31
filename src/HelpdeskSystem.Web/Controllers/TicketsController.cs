using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelpdeskSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;
    private readonly ILogger<TicketsController> _logger;

    public TicketsController(ITicketService ticketService, ILogger<TicketsController> logger)
    {
        _ticketService = ticketService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResultDto<TicketDto>>> GetTickets([FromQuery] TicketFilterDto filter)
    {
        var result = await _ticketService.GetTicketsAsync(filter);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDetailsDto>> GetTicket(string id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<ActionResult<TicketDto>> CreateTicket([FromBody] CreateTicketDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var ticket = await _ticketService.CreateTicketAsync(dto, userId);
        _logger.LogInformation("Ticket {TicketId} created by user {UserId}", ticket.Id, userId);

        return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TicketDto>> UpdateTicket(string id, [FromBody] UpdateTicketDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID mismatch");
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var ticket = await _ticketService.UpdateTicketAsync(dto, userId);
        if (ticket == null)
        {
            return NotFound();
        }

        _logger.LogInformation("Ticket {TicketId} updated by user {UserId}", id, userId);
        return Ok(ticket);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteTicket(string id)
    {
        var result = await _ticketService.DeleteTicketAsync(id);
        if (!result)
        {
            return NotFound();
        }

        _logger.LogInformation("Ticket {TicketId} deleted", id);
        return NoContent();
    }

    [HttpPost("{id}/assign")]
    [Authorize(Roles = "Admin,Agent")]
    public async Task<IActionResult> AssignAgent(string id, [FromBody] string agentId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var result = await _ticketService.AssignAgentAsync(id, agentId, userId);
        if (!result)
        {
            return NotFound();
        }

        _logger.LogInformation("Agent {AgentId} assigned to ticket {TicketId} by {UserId}", agentId, id, userId);
        return Ok();
    }

    [HttpGet("my-tickets")]
    public async Task<ActionResult<List<TicketDto>>> GetMyTickets()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var tickets = await _ticketService.GetUserTicketsAsync(userId);
        return Ok(tickets);
    }

    [HttpGet("assigned")]
    [Authorize(Roles = "Admin,Agent")]
    public async Task<ActionResult<List<TicketDto>>> GetAssignedTickets()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var tickets = await _ticketService.GetAgentTicketsAsync(userId);
        return Ok(tickets);
    }
}
