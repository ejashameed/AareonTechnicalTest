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
    public class NoteControllerTest
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IDataLoggerRepository _logger;
        private readonly ApplicationContext _dbContext;
        private DbContextOptions<ApplicationContext> options;
        private readonly IConfiguration _configuration;
        private string DatabasePath = string.Empty;

        public NoteControllerTest()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).Build();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            //builder.UseSqlite($"Data Source={DatabasePath}");
            options = builder.Options;

            _dbContext = new ApplicationContext(options, _configuration);
            _logger = new SqlLiteDataLogger(_dbContext);
            _ticketRepository = new TicketRepository(_dbContext, _logger);
            _noteRepository = new NoteRepository(_dbContext, _logger);
        }

        #region Test note create
        [Theory]
        [MemberData(nameof(TestDataForCreateNote))]
        public async void CreateNote(params Note[] notesToCreate)
        {
            foreach (var note in notesToCreate)
            {
                await _noteRepository.AddTicketNoteAsync(note);
            }
        }

        public static IEnumerable<Object[]> TestDataForCreateNote()
        {
            yield return new Object[]
            {
                new Note()
                {
                    Content = "Test note 1", CreatedBy = 1, TicketId=26
                },
                new Note()
                {
                    Content = "Test note 2", CreatedBy = 1, TicketId=26
                },
                new Note()
                {
                    Content = "Test note 3", CreatedBy = 1, TicketId=26
                },
            };
        }
        #endregion
        #region note delete
        [Theory]
        [MemberData(nameof(TestDataForDeleteNote))]
        public async void DeleteNote(params Note[] notesToDelete)
        {
            foreach (var note in notesToDelete)
            {
                await _noteRepository.DeleteTicketNoteAsync(note.Id,note.CreatedBy);
            }
        }
        public static IEnumerable<Object[]> TestDataForDeleteNote()
        {
            yield return new Object[]
            {
                new Note()
                {
                    Id = 13, CreatedBy = 4,
                },
                                
            };
        }
        #endregion
    }
}
