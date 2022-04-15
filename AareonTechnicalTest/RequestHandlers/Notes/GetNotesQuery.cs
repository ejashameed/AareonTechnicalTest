using AareonTechnicalTest.Responses;
using MediatR;
using System.Collections.Generic;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class GetNotesQuery: IRequest<List<NoteResponse>>
    {
        public int ticketId { get; set; }
    }
}
