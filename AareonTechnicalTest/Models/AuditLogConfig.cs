using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Models
{
    public class AuditLogConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(
                entity =>
                {
                    entity.ToTable("AuditLogs");
                    entity.HasKey(e => e.Id);
                });
        }
    }
}
