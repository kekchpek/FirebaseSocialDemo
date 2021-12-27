using SocialDemo.Code.Auxiliary.Promises.Factory;
using SocialDemo.Code.Auxiliary.Trigger.Factory;
using SocialDemo.Code.Auxiliary.UnityExecutor;
using UnityEngine;
using Zenject;

namespace SocialDemo.Code.Installers
{
    [CreateAssetMenu(fileName = "CoreInstaller", menuName = "ZenjectInstallers/CoreInstaller", order = 1)]
    public class CoreInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPromiseFactory>().To<PromiseFactory>().AsSingle();
            Container.Bind<ITriggerFactory>().To<TriggerFactory>().AsSingle();
            Container.Bind<IUnityExecutor>().To<UnityExecutor>().AsSingle();
        }
    }
}