using AareonTechnicalTest.Responses;
using MediatR;
using System.Collections.Generic;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class GetTicketQuery: IRequest<List<TicketResponse>>
    {
    }
}
