using System;

namespace SocialDemo.Code.Auxiliary.Exceptions
{
    public class PasswordConfirmMismatchException : Exception
    {
        public const string ErrorMessage = "Passwords don't match!";
        public PasswordConfirmMismatchException() : base(ErrorMessage)
        {
            
        }
    }
}