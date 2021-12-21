using SocialDemo.Code.Mvp.View;
using SocialDemo.Code.Views.LoadingPopup;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public static class ViewDefinitions
    {
        public static readonly ViewDefinition LoadingPopup =
            new ViewDefinition(typeof(LoadingPopupPresenter), ViewType.Popup);
    }
}