using SocialDemo.Code.Mvp.ViewManager;
using UnityEngine;
using Zenject;

namespace SocialDemo.Code
{
    public class StartupBehaviour : MonoBehaviour
    {

        [Inject]
        public void Initialize(IViewManager viewManager)
        {
            viewManager.OpenView(ViewDefinitions.SignIn);
        }
        
    }
}