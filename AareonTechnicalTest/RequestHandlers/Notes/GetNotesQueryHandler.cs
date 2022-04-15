using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Notes
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<NoteResponse>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public GetNotesQueryHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }
        public async Task<List<NoteResponse>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var response = await _noteRepository.GetTicketNotes(request.ticketId);
            var result = _mapper.Map<List<NoteResponse>>(response);
            return result;
        }
    }
}
