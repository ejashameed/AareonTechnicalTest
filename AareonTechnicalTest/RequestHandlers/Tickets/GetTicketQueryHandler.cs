using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, List<TicketResponse>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public GetTicketQueryHandler(IMapper mapper, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketResponse>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var response = await _ticketRepository.GetTicketsAsync();
            var result = _mapper.Map<List<TicketResponse>>(response);
            return result;
        }
    }
}
