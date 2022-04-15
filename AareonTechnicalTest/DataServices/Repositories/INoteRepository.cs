using AareonTechnicalTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataServices.Repositories
{
    public interface INoteRepository
    {
        Task<List<Note>> GetTicketNotes(int ticketId);
        Task<Note> AddTicketNoteAsync(Note note);        
        Task<Note> DeleteTicketNoteAsync(int noteId, int deletedByPersonId);
        Task<Note> UpdateNoteAsync(Note revisedNote);
        Task<Person> GetPersonAsync(int personId);
    }
}
