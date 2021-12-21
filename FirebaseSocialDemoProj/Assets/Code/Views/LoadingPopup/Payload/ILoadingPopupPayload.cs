using SocialDemo.Code.Auxiliary.Trigger;
using SocialDemo.Code.Mvp.Presenter;

namespace SocialDemo.Code.Views.LoadingPopup.Payload
{
    public interface ILoadingPopupPayload : IPresenterPayload
    {
        ITriggerHandler CloseTrigger { get; }
        string LoadingTitle { get; }
        float BackgroundTransparency { get; }
    }
}