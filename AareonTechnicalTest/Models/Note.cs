using System;
using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }        
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

    }
    
}
