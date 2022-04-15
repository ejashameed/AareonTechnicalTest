using AareonTechnicalTest.RequestHandlers.Tickets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers.Tickets
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public IMediator _mediator;

        public TicketController(IServiceProvider serviceProvider)
        {
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        #region Create Ticket
        [HttpPost]
        [Route("CreateTicket")]            
        public async Task<IActionResult> CreateTicket([FromBody]CreateTicketCommand request)
        {
            var newTicket = await _mediator.Send(request);
            return Ok(newTicket);
        }
        #endregion

        [HttpPatch]
        [Route("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket([FromBody]UpdateTicketCommand request)
        {
            var updatedTicket = await _mediator.Send(request);
            return Ok(updatedTicket);
        }

        #region Delete
        [HttpDelete]
        [Route("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(DeleteTicketCommand request)
        {
            var deletedTicket = await _mediator.Send(request);
            return Ok(deletedTicket);
        }
        #endregion

        #region GetTickets
        [HttpGet]
        [Route("GetTickets")]
        public async Task<IActionResult> GetTickets([FromQuery] GetTicketQuery request)
        {
            var tickets = await _mediator.Send(request);
            return Ok(tickets);
        }
        #endregion
    }
}
