using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Views.LoadingPopup;
using SocialDemo.Code.Views.LoadingPopup.View;
using UnityEngine;
using Zenject;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    [CreateAssetMenu(fileName = "MvpInstaller", menuName = "ZenjectInstallers/MvpInstaller", order = 1)]
    public class MvpInstaller : ScriptableObjectInstaller
    {

        private IMvpDiContainer _mvpDiContainer;

        public override void InstallBindings()
        {
            base.InstallBindings();
            
            _mvpDiContainer = new MvpDiContainer(Container);
            Container.Bind<IViewManager>().To<ViewManager.ViewManager>().FromNew().AsSingle();
            Container.Bind<IPresenterProvider>().FromInstance(_mvpDiContainer).AsSingle();
            
            BindModels();
            BindPresenters();
            BindViews();
        }

        private void BindPresenters()
        {
            _mvpDiContainer.BindPresenter<LoadingPopupPresenter>();
        }

        private void BindViews()
        {
            _mvpDiContainer.BindView<ILoadingPopupView, LoadingPopupView>(Resources.Load<GameObject>("Views/LoadingPopupView"));
        }

        private void BindModels()
        {
            
        }
    }
}