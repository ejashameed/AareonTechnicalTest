using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, TicketResponse>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public UpdateTicketCommandHandler(IMapper mapper, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }
        public async Task<TicketResponse> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            // map request object to domain model
            var ticketDomainObject = _mapper.Map<Ticket>(request);

            //update ticket to database
            var resultObject = await _ticketRepository.UpdateAsync(ticketDomainObject);

            // map updated domain object to response
            var responseObject = _mapper.Map<TicketResponse>(resultObject);

            return responseObject;
        }
    }
}
