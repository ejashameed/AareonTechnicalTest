using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketResponse>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }
        public async Task<TicketResponse> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            // fluent validator will validate the inputs

            // map request object to domain model
            var ticketDomainObject = _mapper.Map<Ticket>(request);
            
            //add new ticket to database
            var resultObject = await _ticketRepository.AddTicketAsync(ticketDomainObject);
            
            // map new domain object to response
            var responseObject = _mapper.Map<TicketResponse>(resultObject);

            return responseObject;
            
        }
    }
}
