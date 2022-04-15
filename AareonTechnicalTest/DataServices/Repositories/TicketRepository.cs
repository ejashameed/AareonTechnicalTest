using AareonTechnicalTest.DataLogger;
using AareonTechnicalTest.ExceptionHandlers;
using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataServices.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly IDataLoggerRepository _logger;

        public TicketRepository(ApplicationContext applicationContext, IDataLoggerRepository logger)
        {
            _dbContext = applicationContext;
            _logger = logger;
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            var result = await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();

            #region logging data
            // log changes
            var log = new AuditLog()
            {
                Source = "Tickets",
                CreatedDateTime = DateTime.Now,
                TransactionDateTime = DateTime.Now,
                OperationType = "Create",
                UserId = ticket.PersonId,
                Content = JsonSerializer.Serialize(ticket)
            };
            await _logger.LogData(log);
            #endregion

            return ticket;
        }

        public async Task<Ticket> DeleteTicketAsync(int Id)
        {
            var ticket = await GetTicketAsync(Id);
            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();

            #region logging data
            // log changes
            var log = new AuditLog()
            {
                Source = "Tickets",
                CreatedDateTime = DateTime.Now,
                TransactionDateTime = DateTime.Now,
                OperationType = "Delete",
                UserId = ticket.PersonId,
                Content = JsonSerializer.Serialize(ticket)
            };
            await _logger.LogData(log);
            #endregion

            return ticket;
        }

        public async Task<Ticket> GetTicketAsync(int Id)
        {
            var ticket = await _dbContext.Tickets.Where(t => t.Id == Id).FirstOrDefaultAsync();
            if (ticket == null)
                throw new TicketNotFoundException();
            return ticket;
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            List<Ticket> tickets = new List<Ticket>();
            tickets = await _dbContext.Tickets.ToListAsync();
            return tickets;
        }

        public async Task<Ticket> UpdateAsync(Ticket ticket)
        {
            var ticketToUpdate = await GetTicketAsync(ticket.Id);
            ticketToUpdate.Content = ticket.Content;
            ticketToUpdate.PersonId = ticket.PersonId; 
            _dbContext.Update(ticketToUpdate);
            await _dbContext.SaveChangesAsync();

            #region logging data
            // log changes
            var log = new AuditLog()
            {
                Source = "Tickets",
                CreatedDateTime = DateTime.Now,
                TransactionDateTime = DateTime.Now,
                OperationType = "Update",
                UserId = ticket.PersonId,
                Content = JsonSerializer.Serialize(ticket)
            };
            await _logger.LogData(log);
            #endregion

            return ticket;
        }
    }
}
