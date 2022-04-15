using AareonTechnicalTest.RequestHandlers.Tickets;
using FluentValidation;

namespace AareonTechnicalTest.RequestValidators.Tickets
{
    public class CreateTicketCommandValidator:AbstractValidator<CreateTicketCommand>
    {
        [System.Obsolete]
        public CreateTicketCommandValidator()
        {
            RuleFor(r => r.Content)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Content is empty. This is a required field");
            RuleFor(r => r.PersonId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Person Id is empty. This is a required field");
        }
    }
}
