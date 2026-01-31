using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelpdeskSystem.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly ILogger<CommentsController> _logger;

    public CommentsController(ICommentService commentService, ILogger<CommentsController> logger)
    {
        _commentService = commentService;
        _logger = logger;
    }

    [HttpGet("ticket/{ticketId}")]
    public async Task<ActionResult<List<CommentDto>>> GetCommentsByTicket(string ticketId)
    {
        var comments = await _commentService.GetCommentsByTicketIdAsync(ticketId);
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CreateCommentDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var comment = await _commentService.AddCommentAsync(dto, userId);
        _logger.LogInformation("Comment added to ticket {TicketId} by user {UserId}", dto.TicketId, userId);

        return CreatedAtAction(nameof(GetCommentsByTicket), new { ticketId = dto.TicketId }, comment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(string id)
    {
        var result = await _commentService.DeleteCommentAsync(id);
        if (!result)
        {
            return NotFound();
        }

        _logger.LogInformation("Comment {CommentId} deleted", id);
        return NoContent();
    }
}
