using AareonTechnicalTest.DataServices.Repositories;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Responses;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AareonTechnicalTest.RequestHandlers.Tickets
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, TicketResponse>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public DeleteTicketCommandHandler(IMapper mapper, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }
        public async Task<TicketResponse> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            // fluent validator will validate the inputs
            //delete ticket from db
            var resultObject = await _ticketRepository.DeleteTicketAsync(request.Id);

            // map returned domain object to response
            var responseObject = _mapper.Map<TicketResponse>(resultObject);

            return responseObject;
        }
        
    }
}
