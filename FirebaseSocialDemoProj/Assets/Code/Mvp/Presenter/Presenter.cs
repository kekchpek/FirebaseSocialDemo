using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Mvp.Presenter
{
    public abstract class Presenter<TView, TPayload> : IPresenter
        where TView : IView
        where TPayload : IPresenterPayload
    {
        protected TView View { get; }

        protected Presenter(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Initialize(IPresenterPayload payload = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            View.Close();
        }
    }
}