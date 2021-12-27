using SocialDemo.Code.Auxiliary.Promises;
using SocialDemo.Code.Mvp.Model;

namespace SocialDemo.Code.Domain
{
    public interface ISignInModel : IModel
    {
        IPromise<string> GetUserToken();
        
        bool IsSignedIn { get; }
        
        /// <summary>
        /// Sign in with user login and password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>Returns user's token</returns>
        IPromise<string> SignIn(string login, string password);
        
        /// <summary>
        /// Sign in with google auth provider
        /// </summary>
        /// <returns>Returns user's token</returns>
        IPromise<string> SignInWithGoogle();

        IPromise CreateNewUser(string login, string password);
        
        IPromise SignOut();
    }
}