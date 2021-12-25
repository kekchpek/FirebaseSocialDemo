using System;

namespace SocialDemo.Code.Auxiliary.UnityExecutor
{
    public interface IUnityExecutor
    {
        void ExecuteOnFixedUpdate(Action callback);
        void ExecuteOnUpdate(Action callback);
        void ExecuteOnGui(Action callback);
    }
}