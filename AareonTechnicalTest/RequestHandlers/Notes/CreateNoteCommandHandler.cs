using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, NoteResponse>
    {

        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public CreateNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<NoteResponse> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            // map request object to domain model
            var noteDomainObject = _mapper.Map<Note>(request);

            //add new note to database
            var resultObject = await _noteRepository.AddTicketNoteAsync(noteDomainObject);

            // map new domain note object to response
            var responseObject = _mapper.Map<NoteResponse>(resultObject);

            return responseObject;
        }
    }

    

    
}
