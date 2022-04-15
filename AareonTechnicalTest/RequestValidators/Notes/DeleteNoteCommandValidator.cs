using AareonTechnicalTest.RequestHandlers.Notes;
using FluentValidation;

namespace AareonTechnicalTest.RequestValidators.Notes
{
    public class DeleteNoteCommandValidator: AbstractValidator<DeleteNoteCommand>
    {
        [System.Obsolete]
        public DeleteNoteCommandValidator()
        {
            RuleFor(r => r.noteId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Note Id is empty. This is a required field");
        }
    }
}
