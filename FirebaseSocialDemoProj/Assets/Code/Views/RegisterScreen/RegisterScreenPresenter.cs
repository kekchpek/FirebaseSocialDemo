using SocialDemo.Code.Auxiliary.Exceptions;
using SocialDemo.Code.Auxiliary.Extensions;
using SocialDemo.Code.Domain;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.RegisterScreen.View;

namespace SocialDemo.Code.Views.RegisterScreen
{
    public class RegisterScreenPresenter : Presenter<IRegisterScreenView>
    {
        private readonly IViewManager _viewManager;
        private readonly ISignInModel _signInModel;

        public RegisterScreenPresenter(IRegisterScreenView view,
            IViewManager viewManager,
            ISignInModel signInModel) : base(view)
        {
            _viewManager = viewManager;
            _signInModel = signInModel;
        }

        protected override void Initialize()
        {
            View.RegisterClicked += OnRegisterClicked;
            View.RegistrationSuccessOkClicked += OnRegistrationSuccessOkClicked;
            View.BackClicked += OnBackClicked;
        }

        private void OnRegistrationSuccessOkClicked()
        {
            _viewManager.OpenView(ViewDefinitions.SignIn);
        }

        private void OnBackClicked()
        {
            _viewManager.OpenView(ViewDefinitions.SignIn);
        }

        private void OnRegisterClicked()
        {
            if (View.Email != View.ConfirmedEmail)
            {
                _viewManager.OpenView(ViewDefinitions.ErrorPopup, 
                    new ErrorPopupPayload(EmailConfirmMismatchException.ErrorMessage));
                return;
            }
            
            if (View.Password != View.ConfirmedPassword)
            {
                _viewManager.OpenView(ViewDefinitions.ErrorPopup, 
                    new ErrorPopupPayload(PasswordConfirmMismatchException.ErrorMessage));
                return;
            }

            _signInModel.CreateNewUser(View.Email, View.Password)
                .OnSuccess(() => View.ShowSuccessLayout())
                .OnFail(e => _viewManager.OpenView(ViewDefinitions.ErrorPopup,
                    new ErrorPopupPayload(e.GetErrorMessage())));

        }

        public override void Dispose()
        {
            View.RegistrationSuccessOkClicked -= OnRegistrationSuccessOkClicked;
            View.RegisterClicked -= OnRegisterClicked;
            View.BackClicked -= OnBackClicked;
            base.Dispose();
        }
    }
}