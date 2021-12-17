using SocialDemo.Code.Mvp.ViewManager;
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
            
            InstallModels();
            InstallViews();
            InstallPresenters();
        }

        private void InstallModels()
        {
            
        }

        private void InstallViews()
        {
            
        }

        private void InstallPresenters()
        {
            
        }
    }
}