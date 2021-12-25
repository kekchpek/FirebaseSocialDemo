using SocialDemo.Code.Auxiliary.Promises;
using SocialDemo.Code.Mvp.Model;

namespace SocialDemo.Code.Domain
{
    public interface ISignInModel : IModel
    {
        IPromise<string> GetUserToken();
        bool IsSignedIn { get; }
        IPromise<string> SignIn(string login, string password);
        IPromise<string> SignInWithGoogle();
        IPromise SignOut();
    }
}