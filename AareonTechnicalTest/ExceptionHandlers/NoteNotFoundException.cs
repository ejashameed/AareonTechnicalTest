using System;

namespace AareonTechnicalTest.ExceptionHandlers
{
    public class NoteNotFoundException: Exception
    {
        public NoteNotFoundException()
            : base(String.Format("The note could not be found"))
        {
        }
    }
}
