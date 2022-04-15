using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace AareonTechnicalTest.DataServices
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration iconfiguration)
            : base(options)
        {
            _configuration = iconfiguration;
            DatabasePath = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            //var envDir = Environment.CurrentDirectory;
            //DatabasePath = $"{envDir}{System.IO.Path.DirectorySeparatorChar}Ticketing.db";
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<AuditLog> AuditLogs{get; set;}

        public string DatabasePath { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            PersonConfig.Configure(modelBuilder);
            TicketConfig.Configure(modelBuilder);
            NoteConfig.Configure(modelBuilder);
            AuditLogConfig.Configure(modelBuilder); 
        }
    }
}
