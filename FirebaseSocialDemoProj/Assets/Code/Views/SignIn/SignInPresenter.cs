using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Views.SignIn.View;

namespace SocialDemo.Code.Views.SignIn
{
    public class SignInPresenter : Presenter<ISignInView>
    {
        public SignInPresenter(ISignInView view) : base(view)
        {
        }

        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}