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
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly IDataLoggerRepository _logger;
        public NoteRepository(ApplicationContext applicationContext, IDataLoggerRepository logger)
        {
            _dbContext = applicationContext;
            _logger = logger;
        }

        public async Task<Note> AddTicketNoteAsync(Note note)
        {            
            note.CreatedDateTime = DateTime.Now;
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
            
            #region logging data
            //log changes
            var log = new AuditLog()
            {
                Source = "Notes",
                CreatedDateTime = DateTime.Now,
                TransactionDateTime = note.CreatedDateTime,
                OperationType = "Create",
                UserId = note.CreatedBy,
                Content = JsonSerializer.Serialize(note)
            };
            await _logger.LogData(log);
            #endregion

            return note;
        }

        public async Task<Note> GetTicketNoteAsync(int Id)
        {
            var note = await _dbContext.Notes.Where(n => n.Id.Equals(Id)).FirstOrDefaultAsync();
            if (note == null)
                throw new NoteNotFoundException();
            return note;
        }

        public async Task<Note> DeleteTicketNoteAsync(int noteId, int deletedByPersonId)
        {
            // check Is user authorized to delete note?
            var person = await GetPersonAsync(deletedByPersonId);
            if (person == null)
                throw new PersonNotFoundException();

            if (!person.IsAdmin)
                throw new UserNotAuthorizedException();
            
            //delete from db
            var note = await GetTicketNoteAsync(noteId);
            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();

            #region logging data
            //log changes
            var log = new AuditLog()
            {
                Source = "Notes",
                CreatedDateTime = DateTime.Now,
                TransactionDateTime = note.CreatedDateTime,
                OperationType = "Delete",
                UserId = note.CreatedBy,
                Content = JsonSerializer.Serialize(note)
            };
            await _logger.LogData(log);
            #endregion

            return note;
        }

        public async Task<List<Note>> GetTicketNotes(int ticketId)
        {
            List<Note> notes = new List<Note>();
            notes = await _dbContext.Notes.Where(n => n.TicketId.Equals(ticketId)).ToListAsync();
            return notes;
        }
        
        public async Task<Note> UpdateNoteAsync(Note revisedNote)
        {
            var noteToUpdate = await GetTicketNoteAsync(revisedNote.Id);
            noteToUpdate.Content = revisedNote.Content;
            noteToUpdate.LastUpdatedDateTime = DateTime.Now;
            noteToUpdate.LastUpdatedBy = revisedNote.LastUpdatedBy;
            _dbContext.Update(noteToUpdate);
            await _dbContext.SaveChangesAsync();
            
            #region logging data
            // log changes
            var log = new AuditLog()
            {
                Source = "Notes",
                CreatedDateTime = DateTime.Now,
                TransactionDateTime = noteToUpdate.LastUpdatedDateTime,
                OperationType = "Update",
                UserId = noteToUpdate.LastUpdatedBy,
                Content = JsonSerializer.Serialize(noteToUpdate)
            };
            await _logger.LogData(log);
            #endregion

            return revisedNote;
        }

        public async Task<Person> GetPersonAsync(int personId)
        {
            var person = await _dbContext.Persons.Where(p => p.Id.Equals(personId)).FirstOrDefaultAsync();
            return person;
        }
        
    }
}
