using SocialDemo.Code.Mvp.MvpInstaller;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;
using UnityEngine;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public class ViewManager : IViewManager
    {
        private readonly IPresenterProvider _presenterProvider;

        private IPresenter _currentScreenPresenter;

        public ViewManager(IPresenterProvider presenterProvider)
        {
            _presenterProvider = presenterProvider;
        }
        
        public void OpenView(IViewDefinition viewDefinition, IPresenterPayload presenterPayload = null)
        {
            var newPresenter = _presenterProvider.Obtain(viewDefinition.PresenterType);
            if (newPresenter == null)
            {
                Debug.LogError("Presenter provider returns null! Check that presenter type is specified" +
                               $"correct: {viewDefinition.PresenterType.FullName}");
                return;
            }

            if (viewDefinition.ViewType == ViewType.Screen)
            {
                _currentScreenPresenter?.Dispose();
                _currentScreenPresenter = newPresenter;
            }

            newPresenter.Initialize(presenterPayload);
        }
    }
}