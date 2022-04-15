using AareonTechnicalTest.Models;
using AareonTechnicalTest.Responses;
using AutoMapper;

namespace AareonTechnicalTest.Mappers
{
    public class DomainToResponse: Profile
    {
        public DomainToResponse()
        {
            CreateMap<Ticket, TicketResponse>();
            CreateMap<Note, NoteResponse>();

        }
    }
}
