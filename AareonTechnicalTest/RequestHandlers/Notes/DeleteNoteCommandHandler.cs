using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.ExceptionHandlers;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, NoteResponse>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public DeleteNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }
        public async Task<NoteResponse> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            // fluent validator will validate the inputs

            // Is the user authorized to delete a note?
            var person = await _noteRepository.GetPersonAsync(request.removedByPersonId);
            if (person == null)
                throw new PersonNotFoundException();
            if (!person.IsAdmin)
                throw new UserNotAuthorizedException();

            //delete note from db
            var resultObject = await _noteRepository.DeleteTicketNoteAsync(request.noteId, request.removedByPersonId);

            // map returned domain object to response
            var responseObject = _mapper.Map<NoteResponse>(resultObject);

            return responseObject;
        }
    }
}
