using SocialDemo.Code.Features.LoadingPopup.Payload;
using SocialDemo.Code.Features.LoadingPopup.View;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Features.LoadingPopup
{
    public class LoadingPopupPresenter : Presenter<ILoadingPopupView, ILoadingPopupPayload>
    {

        private ILoadingPopupPayload _payload;
        
        public LoadingPopupPresenter(ILoadingPopupView view) : base(view)
        {
            
        }
        
        protected override void Initialize(ILoadingPopupPayload payload)
        {
            _payload = payload;
            if (_payload != null)
            {
                View.BackgroundTransparency = _payload.BackgroundTransparency;
                View.LoadingTitle = _payload.LoadingTitle;
                _payload.CloseTrigger.OnTriggered += Dispose;
            }
        }

        public override void Dispose()
        {
            if (_payload != null)
            {
                _payload.CloseTrigger.OnTriggered -= Dispose;
            }
            base.Dispose();
        }
    }
}