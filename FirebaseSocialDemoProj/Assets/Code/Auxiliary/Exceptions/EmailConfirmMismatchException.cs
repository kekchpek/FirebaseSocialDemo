using System;

namespace SocialDemo.Code.Auxiliary.Exceptions
{
    public class EmailConfirmMismatchException : Exception
    {
        public const string ErrorMessage = "Emails don't match!";
        public EmailConfirmMismatchException() : base(ErrorMessage)
        {
            
        }
    }
}