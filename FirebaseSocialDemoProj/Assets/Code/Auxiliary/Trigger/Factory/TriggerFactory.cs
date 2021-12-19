namespace SocialDemo.Code.Auxiliary.Trigger.Factory
{
    public class TriggerFactory : ITriggerFactory
    {
        public IRegularTrigger CreateRegularTrigger()
        {
            return new RegularTrigger();
        }
    }
}