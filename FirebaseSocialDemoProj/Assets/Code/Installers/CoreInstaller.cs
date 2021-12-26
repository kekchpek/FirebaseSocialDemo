using SocialDemo.Code.Auxiliary.Promises.Factory;
using SocialDemo.Code.Auxiliary.Trigger.Factory;
using SocialDemo.Code.Auxiliary.UnityExecutor;
using Zenject;

namespace SocialDemo.Code.Installers
{
    public class CoreInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPromiseFactory>().To<PromiseFactory>().AsSingle();
            Container.Bind<ITriggerFactory>().To<TriggerFactory>().AsSingle();
            Container.Bind<IUnityExecutor>().To<UnityExecutor>().AsSingle();
            base.InstallBindings();
        }
    }
}