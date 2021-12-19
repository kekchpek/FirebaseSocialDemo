using System;

namespace SocialDemo.Code.Auxiliary.Trigger
{
    public interface ITriggerHandler
    {
        event Action OnTriggered;
    }
}