using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Views.RegisterScreen.View
{
    public interface IRegisterScreenView : IView
    {
        string Email { get; }
        string ConfirmedEmail { get; }
        string Password { get; }
        string ConfirmedPassword { get; }
        event Action RegisterClicked;
        event Action RegistrationSuccessOkClicked;
        event Action BackClicked;

        void ShowSuccessLayout();
    }
}