using System;
using SocialDemo.Code.Mvp.Presenter;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    public interface IPresenterProvider
    {
        IPresenter Obtain(Type presenterType);
    }
}