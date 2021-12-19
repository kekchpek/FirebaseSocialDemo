using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Mvp.Presenter
{
    public abstract class Presenter<TView, TPayload> : Presenter<TView>
        where TView : IView
        where TPayload : IPresenterPayload
    {

        protected Presenter(TView view) : base(view)
        {
        }

        public sealed override void Initialize(IPresenterPayload payload)
        {
            Initialize((TPayload)payload);
        }

        protected abstract void Initialize(TPayload payload);

        protected sealed override void Initialize()
        {
            throw new Exception("Never should be called!!!");
        }
    }
    
    public abstract class Presenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; }

        protected Presenter(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        public virtual void Initialize(IPresenterPayload payload)
        {
            Initialize();
        }

        protected abstract void Initialize();

        public void Dispose()
        {
            View.Close();
        }
    }
}