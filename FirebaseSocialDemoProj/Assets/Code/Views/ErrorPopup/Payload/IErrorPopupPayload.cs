using SocialDemo.Code.Mvp.Presenter;

namespace SocialDemo.Code.Views.ErrorPopup.Payload
{
    public interface IErrorPopupPayload : IPresenterPayload
    {
        string Message { get; }
        float BackgroundTransparency { get; }
    }
}