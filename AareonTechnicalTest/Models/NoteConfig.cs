using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Models
{
    public class NoteConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(
                entity =>
                {
                    entity.ToTable("Notes");
                    entity.HasKey(e => e.Id);

                    //entity.HasOne(t => t.Ticket)
                    //.WithMany(n => n.Notes)
                    //.HasForeignKey(e => e.TicketId)
                    //.HasConstraintName("ForeignKey_Note_Ticket");                    
                });            
        }
    }
}