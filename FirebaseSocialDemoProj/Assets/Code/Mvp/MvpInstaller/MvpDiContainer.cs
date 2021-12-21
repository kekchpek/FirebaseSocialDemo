using System;
using System.Linq;
using SocialDemo.Code.Mvp.Model;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;
using UnityEngine;
using Zenject;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    public class MvpDiContainer : IMvpDiContainer
    {
        private readonly DiContainer _viewContainer;
        private readonly DiContainer _presenterContainer;
        private readonly DiContainer _modelsContainer;

        public MvpDiContainer(DiContainer globalContainer)
        {
            _presenterContainer = globalContainer.CreateSubContainer();
            _modelsContainer = _presenterContainer.CreateSubContainer();
            _viewContainer =_presenterContainer.CreateSubContainer();
        }
        
        public void BindView<TInterface, TImplementation>(GameObject prefab) 
            where TImplementation : class, TInterface
            where TInterface : IView
        {
            _viewContainer.Bind<TInterface>().To<TImplementation>().FromComponentInNewPrefab(prefab).AsTransient();
        }

        public void BindPresenter<TImplementation>() 
            where TImplementation : class
        {
            _presenterContainer.Bind<TImplementation>().AsTransient();
        }

        public void BindModel<TInterface, TImplementation>() 
            where TInterface : IModel 
            where TImplementation : class, TInterface
        {
            _modelsContainer.Bind<TInterface>().To<TImplementation>().AsSingle();
        }

        public IPresenter Obtain(Type presenterType)
        {
            if (!presenterType.GetInterfaces().Contains(typeof(IPresenter)))
                throw new InvalidOperationException(
                    $"Type {presenterType.FullName} doesn't implement {nameof(IPresenter)} interface");
            return (IPresenter)_presenterContainer.Resolve(presenterType);
        }
    }
}