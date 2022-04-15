using System;
using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }
        public string traceId { get; set; }
        public string Source { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string OperationType { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }        
    }
}
