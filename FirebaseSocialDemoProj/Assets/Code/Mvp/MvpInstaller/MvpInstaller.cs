using SocialDemo.Code.Mvp.Model;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;
using UnityEngine;
using Zenject;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    public class MvpInstaller : IMvpInstaller
    {

        private readonly DiContainer _viewContainer;
        private readonly DiContainer _presenterContainer;
        private readonly DiContainer _modelsContainer;

        public MvpInstaller()
        {
            _presenterContainer = new DiContainer();
            _modelsContainer = _presenterContainer.CreateSubContainer();
            _viewContainer =_presenterContainer.CreateSubContainer();
        }
        
        public void InstallView<TInterface, TImplementation>(GameObject prefab) 
            where TImplementation : class, TInterface
            where TInterface : IView
        {
            _viewContainer.Bind<TInterface>().To<TImplementation>().FromComponentInNewPrefab(prefab).AsTransient();
        }

        public void InstallPresenter<TInterface, TImplementation>() 
            where TImplementation : class, TInterface
            where TInterface : IPresenter
        {
            _presenterContainer.Bind<TInterface>().To<TImplementation>().AsTransient();
        }

        public void InstallModel<TInterface, TImplementation>() 
            where TInterface : IModel 
            where TImplementation : class, TInterface
        {
            _modelsContainer.Bind<TInterface>().To<TImplementation>().AsSingle();
        }
    }
}