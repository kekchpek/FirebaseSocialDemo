using SocialDemo.Code.Mvp.Presenter;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public interface IViewManager
    {
        void OpenView(IViewDefinition viewDefinition, IPresenterPayload presenterPayload = null);
    }
}