using System;
using System.Text.Json.Serialization;

namespace AareonTechnicalTest.Responses
{
    public class NoteResponse
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        
        public virtual TicketResponse TicketResponse { get; set; }
    }
}
