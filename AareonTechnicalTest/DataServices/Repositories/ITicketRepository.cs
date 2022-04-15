using AareonTechnicalTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataServices.Repositories
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetTicketsAsync();        
        Task<Ticket> AddTicketAsync(Ticket ticket);
        Task<Ticket> DeleteTicketAsync(int Id);        
        Task<Ticket> UpdateAsync(Ticket ticket);
    }
}
    