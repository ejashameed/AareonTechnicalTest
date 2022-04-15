using AareonTechnicalTest.RequestHandlers.Tickets;
using FluentValidation;

namespace AareonTechnicalTest.RequestValidators.Tickets
{
    public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
    {
        [System.Obsolete]
        public UpdateTicketCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Ticket Id is empty. This is a required field");
            RuleFor(r => r.Content)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Content is empty. This is a required field");
            RuleFor(r => r.PersonId)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Person Id is empty. This is a required field");
        }        
    }
}
