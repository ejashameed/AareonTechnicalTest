using AareonTechnicalTest.Models;
using AareonTechnicalTest.RequestHandlers.Notes;
using AareonTechnicalTest.RequestHandlers.Tickets;
using AareonTechnicalTest.Responses;
using AutoMapper;

namespace AareonTechnicalTest.Mappers
{
    public class ResponseToDomain: Profile
    {
        public ResponseToDomain()
        {
            CreateMap<CreateTicketCommand, Ticket>();
            CreateMap<UpdateTicketCommand, Ticket>();

            CreateMap<CreateNoteCommand, Note>();
            CreateMap<UpdateNoteCommand, Note>();

        }
    }
}
