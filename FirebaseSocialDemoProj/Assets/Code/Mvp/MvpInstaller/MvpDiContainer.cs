using System;
using System.Linq;
using System.Net.NetworkInformation;
using SocialDemo.Code.Mvp.Model;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    public class MvpDiContainer : IMvpDiContainer
    {

        private const string MainCanvasId = "MainCanvas";
        
        private readonly DiContainer _viewContainer;
        private readonly DiContainer _presenterContainer;
        private readonly DiContainer _modelsContainer;

        public MvpDiContainer(DiContainer globalContainer)
        {
            _presenterContainer = globalContainer.CreateSubContainer();
            _modelsContainer = _presenterContainer.CreateSubContainer();
            _viewContainer =_presenterContainer.CreateSubContainer();
            _viewContainer.Bind<Canvas>().WithId(MainCanvasId).FromNewComponentOnNewGameObject()
                .WithGameObjectName(MainCanvasId).AsSingle().OnInstantiated(
                (context, obj) =>
                {
                    var canvas = (Canvas)obj;
                    SceneManager.MoveGameObjectToScene(canvas.gameObject, SceneManager.GetActiveScene());
                    canvas.renderMode = RenderMode.ScreenSpaceCamera;
                    canvas.worldCamera = Camera.main;
                    canvas.gameObject.AddComponent<GraphicRaycaster>();
                });
        }
        
        public void BindView<TInterface, TImplementation>(GameObject prefab) 
            where TImplementation : class, TInterface
            where TInterface : IView
        {
            _viewContainer.Bind<TInterface>().To<TImplementation>().FromComponentInNewPrefab(prefab).UnderTransform(GetMainCanvasTransform).AsTransient();
            _presenterContainer.Bind<TInterface>().FromSubContainerResolve().ByInstance(_viewContainer).AsTransient();
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
            _presenterContainer.Bind<TInterface>().FromSubContainerResolve().ByInstance(_modelsContainer).AsSingle();
        }

        public IPresenter Obtain(Type presenterType)
        {
            if (!presenterType.GetInterfaces().Contains(typeof(IPresenter)))
                throw new InvalidOperationException(
                    $"Type {presenterType.FullName} doesn't implement {nameof(IPresenter)} interface");
            return (IPresenter)_presenterContainer.Resolve(presenterType);
        }

        private Transform GetMainCanvasTransform(InjectContext context)
        {
            return _viewContainer.ResolveId<Canvas>(MainCanvasId).transform;
        }
    }
}