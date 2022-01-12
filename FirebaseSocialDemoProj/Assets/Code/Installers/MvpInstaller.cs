using SocialDemo.Code.Domain;
using SocialDemo.Code.Mvp.MvpInstaller;
using SocialDemo.Code.Views.ErrorPopup;
using SocialDemo.Code.Views.ErrorPopup.View;
using SocialDemo.Code.Views.LoadingPopup;
using SocialDemo.Code.Views.LoadingPopup.View;
using SocialDemo.Code.Views.RegisterScreen;
using SocialDemo.Code.Views.RegisterScreen.View;
using SocialDemo.Code.Views.SignIn;
using SocialDemo.Code.Views.SignIn.View;
using UnityEngine;

namespace SocialDemo.Code.Installers
{
    [CreateAssetMenu(fileName = "MvpInstaller", menuName = "ZenjectInstallers/MvpInstaller", order = 1)]
    public class MvpInstaller : MvpBaseInstaller
    {
        protected override void BindPresenters(IMvpDiContainer mvpDiContainer)
        {
            mvpDiContainer.BindPresenter<LoadingPopupPresenter>();
            mvpDiContainer.BindPresenter<ErrorPopupPresenter>();
            mvpDiContainer.BindPresenter<SignInPresenter>();
            mvpDiContainer.BindPresenter<RegisterScreenPresenter>();
        }

        protected override void BindViews(IMvpDiContainer mvpDiContainer)
        {
            mvpDiContainer.BindView<ILoadingPopupView, LoadingPopupView>(Resources.Load<GameObject>("Views/LoadingPopupView"));
            mvpDiContainer.BindView<IErrorPopupView, ErrorPopupView>(Resources.Load<GameObject>("Views/ErrorPopupView"));
            mvpDiContainer.BindView<ISignInView, SignInView>(Resources.Load<GameObject>("Views/SignInView"));
            mvpDiContainer.BindView<IRegisterScreenView, RegisterScreenView>(Resources.Load<GameObject>("Views/RegisterScreen"));
        }

        protected override void BindModels(IMvpDiContainer mvpDiContainer)
        {
            mvpDiContainer.BindModel<ISignInModel, SignInModel>();
        }
    }
}