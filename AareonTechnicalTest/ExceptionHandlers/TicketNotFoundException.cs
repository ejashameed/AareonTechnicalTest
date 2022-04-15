using System;

namespace AareonTechnicalTest.ExceptionHandlers
{
    public class TicketNotFoundException: Exception
    {
        public TicketNotFoundException()
            : base(String.Format("The ticket could not be found"))
        {
        }
    }
}
