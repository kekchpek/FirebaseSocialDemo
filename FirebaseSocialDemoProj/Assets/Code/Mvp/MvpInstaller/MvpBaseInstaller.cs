using SocialDemo.Code.Mvp.ViewManager;
using Zenject;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    public abstract class MvpBaseInstaller : ScriptableObjectInstaller
    {

        private IMvpDiContainer _mvpDiContainer;

        public override void InstallBindings()
        {
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