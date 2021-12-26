using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.ErrorPopup.View;

namespace SocialDemo.Code.Views.ErrorPopup
{
    public class ErrorPopupPresenter : Presenter<IErrorPopupView, IErrorPopupPayload>
    {
        public ErrorPopupPresenter(IErrorPopupView view) : base(view)
        {
        }

        protected override void Initialize(IErrorPopupPayload payload)
        {
            View.Message = payload.Message;
            View.BackgroundTransparency = payload.BackgroundTransparency;
            View.CloseClicked += Dispose;
        }

        public override void Dispose()
        {
            View.CloseClicked -= Dispose;
            base.Dispose();
        }
    }
}