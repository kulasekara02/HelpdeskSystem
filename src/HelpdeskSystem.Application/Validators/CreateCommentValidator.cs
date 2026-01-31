using FluentValidation;
using HelpdeskSystem.Application.DTOs;

namespace HelpdeskSystem.Application.Validators;

public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentValidator()
    {
        RuleFor(x => x.TicketId)
            .NotEmpty().WithMessage("Ticket ID is required");

        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Comment text is required")
            .MaximumLength(4000).WithMessage("Comment cannot exceed 4000 characters");
    }
}
