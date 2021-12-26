using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Views.LoadingPopup;
using SocialDemo.Code.Views.LoadingPopup.View;
using UnityEngine;
using Zenject;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    [CreateAssetMenu(fileName = "MvpInstaller", menuName = "ZenjectInstallers/MvpInstaller", order = 1)]
    public abstract class MvpBaseInstaller : ScriptableObjectInstaller
    {

        private IMvpDiContainer _mvpDiContainer;

        public override void InstallBindings()
        {
            base.InstallBindings();
            
            _mvpDiContainer = new MvpDiContainer(Container);
            Container.Bind<IViewManager>().To<ViewManager.ViewManager>().FromNew().AsSingle();
            Container.Bind<IPresenterProvider>().FromInstance(_mvpDiContainer).AsSingle();
            BindModels(_mvpDiContainer);
            BindPresenters(_mvpDiContainer);
            BindViews(_mvpDiContainer);
        }

        protected abstract void BindPresenters(IMvpDiContainer mvpDiContainer);

        protected abstract void BindViews(IMvpDiContainer mvpDiContainer);

        protected abstract void BindModels(IMvpDiContainer mvpDiContainer);
    }
}