using FluentValidation;
using HelpdeskSystem.Application.DTOs;

namespace HelpdeskSystem.Application.Validators;

public class CreateTicketValidator : AbstractValidator<CreateTicketDto>
{
    public CreateTicketValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(4000).WithMessage("Description cannot exceed 4000 characters");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("Invalid priority value");
    }
}

public class UpdateTicketValidator : AbstractValidator<UpdateTicketDto>
{
    public UpdateTicketValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Ticket ID is required");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(4000).WithMessage("Description cannot exceed 4000 characters");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("Invalid priority value");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status value");
    }
}
