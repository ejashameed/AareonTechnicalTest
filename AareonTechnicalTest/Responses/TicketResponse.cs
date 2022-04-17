using AareonTechnicalTest.Models;
using System.Collections.Generic;

namespace AareonTechnicalTest.Responses
{
    public class TicketResponse
    {
        public TicketResponse()
        {
            Notes = new HashSet<NoteResponse>();
        }
        public int Id { get; set; }

        public string Content { get; set; }

        public int PersonId { get; set; }

        public virtual ICollection<NoteResponse> Notes { get; set; }
    }
}
