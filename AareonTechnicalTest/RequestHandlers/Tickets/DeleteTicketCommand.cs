using AareonTechnicalTest.Responses;
using MediatR;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class DeleteTicketCommand: IRequest<TicketResponse>
    {
        public int Id { get; set; }
        
    }
}
