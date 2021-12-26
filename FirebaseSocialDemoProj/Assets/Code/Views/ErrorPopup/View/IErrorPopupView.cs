using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Views.ErrorPopup.View
{
    public interface IErrorPopupView : IView
    {
        string Message { get; set; }
        float BackgroundTransparency { get; set; }
        event Action CloseClicked;
    }
}