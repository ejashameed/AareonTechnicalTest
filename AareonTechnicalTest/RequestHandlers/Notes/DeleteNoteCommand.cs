using AareonTechnicalTest.Responses;
using MediatR;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class DeleteNoteCommand: IRequest<NoteResponse>
    {
        public int noteId { get; set; }
        public int removedByPersonId { get; set; }
    }
}

