using AareonTechnicalTest.Responses;
using MediatR;
using System;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class UpdateNoteCommand: IRequest<NoteResponse>
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Content { get; set; }
        public int LastUpdatedBy { get; set; }        

    }
}
