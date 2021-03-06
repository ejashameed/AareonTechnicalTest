using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Models
{
    public static class PersonConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(
                entity =>
                {
                    entity.ToTable("Persons");
                    entity.HasKey(e => e.Id);
                });
        }
    }
}