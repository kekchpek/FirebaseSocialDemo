using System;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Auth;
using SocialDemo.Code.Auxiliary.Promises;
using SocialDemo.Code.Auxiliary.Promises.Factory;

namespace SocialDemo.Code.Domain
{
    public class SignInModel : ISignInModel
    {
        private readonly IPromiseFactory _promiseFactory;
        private FirebaseAuth _authApi = FirebaseAuth.DefaultInstance;

        public SignInModel(IPromiseFactory promiseFactory)
        {
            _promiseFactory = promiseFactory;
        }

        public IPromise<string> GetUserToken()
        {
            if (_authApi.CurrentUser == null)
                return _promiseFactory.CreateFailedPromise<string>(
                    new InvalidOperationException("User is not signed in."));
            return _promiseFactory.CreateFromTask(_authApi.CurrentUser.TokenAsync(false));
        }

        public bool IsSignedIn => _authApi.CurrentUser != null;

        public IPromise<string> SignIn(string login, string password)
        {
            return WrapSignInTask(_authApi.SignInWithEmailAndPasswordAsync(login, password));
        }

        public IPromise<string> SignInWithGoogle()
        {
            var data = new FederatedOAuthProviderData();
            data.ProviderId = GoogleAuthProvider.ProviderId;
            var provider = new FederatedOAuthProvider(data);
            provider.SetProviderData(data);
            return WrapSignInTask(_authApi.SignInWithProviderAsync(provider).ContinueWith(t =>
            {
                t.Wait();
                return t.Result.User;
            }));
        }

        public IPromise SignOut()
        {
            _authApi.SignOut();
            return _promiseFactory.CreateSucceedPromise();
        }

        private IPromise<string> WrapSignInTask(Task<FirebaseUser> task)
        {
            var tokenSemaphore = new SemaphoreSlim(0, 1);
            Exception getTokenException = null;
            string userToken = null;
            var getTokenTask = Task.Run(() =>
            {
                tokenSemaphore.Wait();
                if (getTokenException != null)
                    throw getTokenException;
                return userToken;
            });

            var signInTask = task;
            signInTask.ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    getTokenException = t.Exception;
                    tokenSemaphore.Release();
                    return;
                }
                t.Result.TokenAsync(false)
                    .ContinueWith(tokenTask =>
                    {
                        if (tokenTask.Exception != null)
                        {
                            getTokenException = t.Exception;
                        }
                        else
                        {
                            userToken = tokenTask.Result;
                        }
                        tokenSemaphore.Release();
                    }, TaskContinuationOptions.ExecuteSynchronously);
            }, TaskContinuationOptions.ExecuteSynchronously);
            
            return _promiseFactory.CreateFromTask(getTokenTask);
        }
    }
}