using SocialDemo.Code.Mvp.MvpInstaller;
using SocialDemo.Code.Mvp.Presenter;
using UnityEngine;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public class ViewManager : IViewManager
    {
        private readonly IPresenterProvider _presenterProvider;

        private IPresenter _currentPresenter = null;

        public ViewManager(IPresenterProvider presenterProvider)
        {
            _presenterProvider = presenterProvider;
        }
        
        public void OpenView(IViewDefinition viewDefinition)
        {
            var newPresenter = _presenterProvider.Obtain(viewDefinition.PresenterType);
            if (newPresenter == null)
            {
                Debug.LogError("Presenter provider returns null! Check that presenter type is specified" +
                               $"correct {viewDefinition.PresenterType.FullName}");
                return;
            }
            _currentPresenter?.Dispose();
            _currentPresenter = newPresenter;
            _currentPresenter.Initialize();
        }
    }
}