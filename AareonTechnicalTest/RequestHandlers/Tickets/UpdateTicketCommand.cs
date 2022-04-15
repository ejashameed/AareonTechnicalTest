using AareonTechnicalTest.Responses;
using MediatR;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class UpdateTicketCommand: IRequest<TicketResponse>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PersonId { get; set; }
    }
}
