using System;
using SocialDemo.Code.Auxiliary.Trigger.Factory;

namespace SocialDemo.Code.Auxiliary.Trigger
{
    public class RegularTrigger : IRegularTrigger
    {
        public event Action OnTriggered;
        public void Trigger()
        {
            OnTriggered?.Invoke();   
        }
    }
}