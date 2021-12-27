using SocialDemo.Code.Auxiliary.Extensions;
using SocialDemo.Code.Domain;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.SignIn.View;

namespace SocialDemo.Code.Views.SignIn
{
    public class SignInPresenter : Presenter<ISignInView>
    {
        private readonly ISignInModel _signInModel;
        private readonly IViewManager _viewManager;

        public SignInPresenter(ISignInView view,
            ISignInModel signInModel,
            IViewManager viewManager) : base(view)
        {
            _signInModel = signInModel;
            _viewManager = viewManager;
        }

        protected override void Initialize()
        {
            View.LoginGoogleClicked += OnGoogleSingInClicked;
            View.LoginClicked += OnSignInClicked;
        }

        private void OnGoogleSingInClicked()
        {
            _signInModel.SignInWithGoogle()
                .OnFail(e => _viewManager.OpenView(ViewDefinitions.ErrorPopup, new ErrorPopupPayload(e.GetErrorMessage())));
        }

        private void OnSignInClicked()
        {
            _signInModel.SignIn(View.Login, View.Password)
                .OnFail(e => _viewManager.OpenView(ViewDefinitions.ErrorPopup, new ErrorPopupPayload(e.GetErrorMessage())));
        }
    }
}