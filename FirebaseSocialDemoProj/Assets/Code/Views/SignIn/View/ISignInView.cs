using System;

namespace SocialDemo.Code.Views.SignIn.View
{
    public interface ISignInView
    {
        string Login { get; }
        string Password { get; }
        event Action LoginClicked;
    }
}