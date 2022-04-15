using AareonTechnicalTest.RequestHandlers.Notes;
using FluentValidation;

namespace AareonTechnicalTest.RequestValidators.Notes
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        [System.Obsolete]
        public UpdateNoteCommandValidator()
        {
            RuleFor(r => r.Id)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Note Id is empty. This is a required field");

            RuleFor(r => r.TicketId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Ticket Id is empty. This is a required field");

            RuleFor(r => r.Content)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Content is empty. This is a required field");

            RuleFor(r => r.LastUpdatedBy)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("Last updated Person is empty. This is a required field");

        }
    }
}

