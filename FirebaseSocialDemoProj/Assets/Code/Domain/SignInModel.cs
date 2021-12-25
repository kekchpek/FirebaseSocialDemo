using SocialDemo.Code.Auxiliary.Promises;
using SocialDemo.Code.Auxiliary.UnityExecutor;

namespace SocialDemo.Code.Domain
{
    public class SignInModel : ISignInModel
    {

        public SignInModel(IUnityExecutor unityExecutor)
        {
            
        }
        
        public string UserToken { get; }
        public bool IsSignedIn { get; }
        public IPromise<string> SignIn(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        public IPromise<string> SignOut()
        {
            throw new System.NotImplementedException();
        }
    }
}