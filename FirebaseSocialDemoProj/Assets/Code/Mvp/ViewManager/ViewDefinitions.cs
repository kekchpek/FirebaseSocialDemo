using SocialDemo.Code.Mvp.View;
using SocialDemo.Code.Views.ErrorPopup;
using SocialDemo.Code.Views.ErrorPopup.View;
using SocialDemo.Code.Views.LoadingPopup;
using SocialDemo.Code.Views.SignIn;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public static class ViewDefinitions
    {
        public static readonly ViewDefinition LoadingPopup =
            new ViewDefinition(typeof(LoadingPopupPresenter), ViewType.Popup);
        public static readonly ViewDefinition ErrorPopup =
            new ViewDefinition(typeof(ErrorPopupPresenter), ViewType.Popup);
        public static readonly ViewDefinition SignIn =
            new ViewDefinition(typeof(SignInPresenter), ViewType.Screen);
    }
}