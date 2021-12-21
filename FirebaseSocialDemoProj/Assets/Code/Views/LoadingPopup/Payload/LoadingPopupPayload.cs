using SocialDemo.Code.Auxiliary.Trigger;

namespace SocialDemo.Code.Views.LoadingPopup.Payload
{
    public class LoadingPopupPayload : ILoadingPopupPayload
    {
        public ITriggerHandler CloseTrigger { get; }
        public string LoadingTitle { get; }
        public float BackgroundTransparency { get; }
        public LoadingPopupPayload(ITriggerHandler closeTrigger = null,
            string loadingTitle = null,
            float backgroundTransparency = 0.1f)
        {
            CloseTrigger = closeTrigger;
            LoadingTitle = loadingTitle;
            BackgroundTransparency = backgroundTransparency;
        }
    }
}