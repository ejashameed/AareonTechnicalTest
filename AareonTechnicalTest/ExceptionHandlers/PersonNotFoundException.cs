using System;

namespace AareonTechnicalTest.ExceptionHandlers
{
    public class PersonNotFoundException: Exception
    {
        public PersonNotFoundException()
            : base(String.Format("Person Id not found in the database"))
        {
        }
    }
}
