using AareonTechnicalTest.Responses;
using MediatR;
using System;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class CreateNoteCommand: IRequest<NoteResponse>
    {
        public int TicketId { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }       
    }
}
