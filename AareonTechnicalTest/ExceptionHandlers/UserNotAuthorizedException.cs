using System;

namespace AareonTechnicalTest.ExceptionHandlers
{
    public class UserNotAuthorizedException: Exception
    {
        public UserNotAuthorizedException()
            : base(String.Format("Person not authorized to delete the note"))
        {
        }
    }
}
