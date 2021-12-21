using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Views.LoadingPopup.View
{
    public interface ILoadingPopupView : IView
    {
        string LoadingTitle { get; set; }
        
        /// <summary>
        /// 0f - visible; 1f - hidden
        /// </summary>
        float BackgroundTransparency { get; set; }
    }
}