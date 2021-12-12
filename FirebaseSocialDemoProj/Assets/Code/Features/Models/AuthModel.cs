using System.Threading.Tasks;
using Firebase.Auth;
using Google;

namespace SocialDemo.Code.Features.Models {
    
    public class AuthModel : IAuthModel
    {

        private const string WebClientId = "918265263992-6odnvligs632hl9gho33nn6o6mktr38g.apps.googleusercontent.com";
        
        private readonly GoogleSignIn _apiGoogleAuthEntryPoint = GoogleSignIn.DefaultInstance;
        private readonly FirebaseAuth _apiAuthEntryPoint = FirebaseAuth.DefaultInstance;
        
        public void Initialize()
        {
            GoogleSignIn.Configuration = new GoogleSignInConfiguration {
                WebClientId = WebClientId,
                RequestIdToken = true,
                UseGameSignIn = false,
            };
        }
        
        public async Task<string> LoginWithGoogle()
        {
            var loginTask = _apiGoogleAuthEntryPoint.SignIn();
            await loginTask;
            if (loginTask.Exception != null)
                throw loginTask.Exception;
            return loginTask.Result.UserId;
        }
        
        public async Task<string> Login(string login, string pass)
        {
            var loginTask = _apiAuthEntryPoint.SignInWithEmailAndPasswordAsync(login, pass);
            await loginTask;
            if (loginTask.Exception != null)
                throw loginTask.Exception;
            return loginTask.Result.UserId;
        }
    }
    
}
