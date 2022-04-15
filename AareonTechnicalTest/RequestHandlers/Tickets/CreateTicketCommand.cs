using AareonTechnicalTest.Responses;
using MediatR;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class CreateTicketCommand: IRequest<TicketResponse>
    {
        public string Content { get; set; }

        public int PersonId { get; set; }
    }
}
