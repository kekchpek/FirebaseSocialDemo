using SocialDemo.Code.Auxiliary.Extensions;
using SocialDemo.Code.Auxiliary.Trigger.Factory;
using SocialDemo.Code.Domain;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.LoadingPopup.Payload;
using SocialDemo.Code.Views.SignIn.View;

namespace SocialDemo.Code.Views.SignIn
{
    public class SignInPresenter : Presenter<ISignInView>
    {
        private readonly ISignInModel _signInModel;
        private readonly IViewManager _viewManager;
        private readonly ITriggerFactory _triggerFactory;

        public SignInPresenter(ISignInView view,
            ISignInModel signInModel,
            IViewManager viewManager,
            ITriggerFactory triggerFactory) : base(view)
        {
            _signInModel = signInModel;
            _viewManager = viewManager;
            _triggerFactory = triggerFactory;
        }

        protected override void Initialize()
        {
            View.LoginGoogleClicked += OnGoogleSingInClicked;
            View.LoginClicked += OnSignInClicked;
            View.RegisterClicked += OnRegisterClicked;
        }

        private void OnRegisterClicked()
        {
            _viewManager.OpenView(ViewDefinitions.RegisterScreen);
        }

        private void OnGoogleSingInClicked()
        {
            _signInModel.SignInWithGoogle()
                .OnFail(e => _viewManager.OpenView(ViewDefinitions.ErrorPopup, new ErrorPopupPayload(e.GetErrorMessage())));
        }

        private void OnSignInClicked()
        {
            var closeTrigger = _triggerFactory.CreateRegularTrigger();
            var loadingPayload = new LoadingPopupPayload(closeTrigger, "SIGNING IN...");
            _viewManager.OpenView(ViewDefinitions.LoadingPopup, loadingPayload);
            _signInModel.SignIn(View.Login, View.Password)
                .OnFail(e => _viewManager.OpenView(ViewDefinitions.ErrorPopup, new ErrorPopupPayload(e.GetErrorMessage())))
                .Finally(() => closeTrigger.Trigger());
        }
    }
}