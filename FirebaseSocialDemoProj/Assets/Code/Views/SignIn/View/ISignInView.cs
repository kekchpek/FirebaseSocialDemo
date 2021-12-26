using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Views.SignIn.View
{
    public interface ISignInView : IView
    {
        string Login { get; }
        string Password { get; }
        event Action LoginClicked;
        event Action LoginGoogleClicked;
    }
}