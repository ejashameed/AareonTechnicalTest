using AareonTechnicalTest.DataLogger;
using AareonTechnicalTest.DataServices;
using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AareonTechnicalTest.UnitTest
{
    public class TicketControllerTest
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IDataLoggerRepository _logger;
        private readonly ApplicationContext _dbContext;
        private DbContextOptions<ApplicationContext> options;        
        private readonly IConfiguration _configuration;

        private string DatabasePath = string.Empty;
        
        public TicketControllerTest()
        {         
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).Build();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            //builder.UseSqlite($"Data Source={DatabasePath}");
            options = builder.Options;

            _dbContext = new ApplicationContext(options,_configuration);                    
            _logger = new SqlLiteDataLogger(_dbContext);
            _ticketRepository = new TicketRepository(_dbContext,_logger);
            _noteRepository = new NoteRepository(_dbContext,_logger);
       
        }

        #region test create ticket
        [Theory]
        [MemberData(nameof(TestDataForCreateTicket))]
        public async void CreateTicket(params Ticket[] ticketsToCreate)
        {
            foreach (var ticket in ticketsToCreate)
            {
                await _ticketRepository.AddTicketAsync(ticket);
            }            
        }

        public static IEnumerable<Object[]> TestDataForCreateTicket()
        {
            yield return new Object[]
            {
                new Ticket()
                {
                    Content = "Test ticket 1", PersonId = 1
                },
                new Ticket()
                {
                    Content = "Test ticket 2", PersonId = 2
                },
                new Ticket()
                {
                    Content = "Test ticket 3", PersonId = 4
                },
            };            
        }
        #endregion
       
    }
}
