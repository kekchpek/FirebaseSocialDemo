using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Mvp.Presenter
{
    public interface IPresenter : IDisposable
    {
        void Initialize(IPresenterPayload payload = null);
    }
}