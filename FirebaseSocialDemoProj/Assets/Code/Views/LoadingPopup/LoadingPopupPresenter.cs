using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Views.LoadingPopup.Payload;
using SocialDemo.Code.Views.LoadingPopup.View;

namespace SocialDemo.Code.Views.LoadingPopup
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
            if (_payload == null) return;
            View.BackgroundTransparency = _payload.BackgroundTransparency;
            View.LoadingTitle = _payload.LoadingTitle;
            _payload.CloseTrigger.OnTriggered += Dispose;
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