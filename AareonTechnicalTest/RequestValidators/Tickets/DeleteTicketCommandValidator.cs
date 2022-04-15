using AareonTechnicalTest.RequestHandlers.Tickets;
using FluentValidation;

namespace AareonTechnicalTest.RequestValidators.Tickets
{
    public class DeleteTicketCommandValidator:AbstractValidator<DeleteTicketCommand>
    {
        public DeleteTicketCommandValidator()
        {
            RuleFor(r => r.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Ticket Id is empty. This is a required field");           
        }
    }
}
