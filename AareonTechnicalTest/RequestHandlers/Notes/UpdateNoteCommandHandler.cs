using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class UpdateNoteCommandHandler: IRequestHandler<UpdateNoteCommand, NoteResponse>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public UpdateNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<NoteResponse> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            // map request object to domain model
            var noteDomainObject = _mapper.Map<Note>(request);

            //update note to database
            var resultObject = await _noteRepository.UpdateNoteAsync(noteDomainObject);

            // map updated domain object to response
            var responseObject = _mapper.Map<NoteResponse>(resultObject);

            return responseObject;
        }
    }
}
