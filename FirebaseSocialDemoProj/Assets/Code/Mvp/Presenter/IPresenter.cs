using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Mvp.Presenter
{ 
    public interface IPresenter
    {
        
    }
    
    public interface IPresenter<TView> : IPresenter where TView : IView
    {

    }
}