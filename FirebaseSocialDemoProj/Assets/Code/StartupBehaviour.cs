using System;
using Firebase;
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
            FirebaseApp.Create(new AppOptions()
            {
                AppId = "1:918265263992:ios:2dd4bad05c038b0451ba8d",
                ApiKey = "AIzaSyCCh0AbsxyoZ3UNV_d0FWvDBBF2nq68Q4c",
                StorageBucket = "social-demo-firebase.appspot.com",
                ProjectId = "social-demo-firebase",
                DatabaseUrl = new Uri("https://social-demo-firebase-default-rtdb.europe-west1.firebasedatabase.app"),
            });
            viewManager.OpenView(ViewDefinitions.SignIn);
        }
        
    }
}