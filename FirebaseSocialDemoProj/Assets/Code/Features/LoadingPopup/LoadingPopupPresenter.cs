using SocialDemo.Code.Features.LoadingPopup.Payload;
using SocialDemo.Code.Features.LoadingPopup.View;
using SocialDemo.Code.Mvp.Presenter;

namespace SocialDemo.Code.Features.LoadingPopup
{
    public class LoadingPopupPresenter : Presenter<ILoadingPopupView, ILoadingPopupPayload>
    {
        public LoadingPopupPresenter(ILoadingPopupView view) : base(view)
        {
            
        }

        protected override void Initialize(ILoadingPopupPayload payload)
        {
            
        }
    }
}