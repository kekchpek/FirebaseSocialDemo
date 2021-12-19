using System.Threading.Tasks;

namespace SocialDemo.Code.Features.Models
{
    public interface ISignInModel
    {
        void Initialize();
        
        /// <summary>
        /// Login into game cloud services via Google
        /// </summary>
        /// <returns>Returns user id</returns>
        Task<string> LoginWithGoogle();
        
        /// <summary>
        /// Login into game cloud services
        /// </summary>
        /// <returns>Returns user id</returns>
        Task<string> Login(string login, string pass);
    }
}