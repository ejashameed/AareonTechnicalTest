using AareonTechnicalTest.RequestHandlers.Notes;
using FluentValidation;

namespace AareonTechnicalTest.RequestValidators.Notes
{
    public class CreateNoteCommandValidator:AbstractValidator<CreateNoteCommand>
    {
        [System.Obsolete]
        public CreateNoteCommandValidator()
        {
            RuleFor(r => r.TicketId)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Ticket Id is empty. This is a required field");
            RuleFor(r => r.Content)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Content is empty. This is a required field");
            RuleFor(r => r.CreatedBy)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Created by Person is empty. This is a required field");
        }
    }
}
