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
            await _logger.LogData<Ticket>(ticket, "Tickets", "Create");
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
            await _logger.LogData<Ticket>(ticket, "Tickets", "Delete");            
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
            var tickets = await _dbContext.Tickets
                    .Include(n => n.Notes)
                    .ToListAsync();

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
            await _logger.LogData<Ticket>(ticket, "Tickets", "Update");            
            #endregion

            return ticket;
        }
    }
}
