using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Mvp.Presenter
{
    public abstract class Presenter<TView> : IPresenter where TView : IView
    {
        protected TView View { get; }

        public Presenter(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Dispose()
        {
            View.Close();
        }

        public virtual void Initialize()
        {
            // will be overriden in child classes
        }
    }
}