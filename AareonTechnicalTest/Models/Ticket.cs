using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AareonTechnicalTest.Models
{
    public class Ticket
    {
        public Ticket()
        {
            Notes = new HashSet<Note>();
        }

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public int PersonId { get; set; }        
        public virtual ICollection<Note> Notes { get; set; }
    }
}
