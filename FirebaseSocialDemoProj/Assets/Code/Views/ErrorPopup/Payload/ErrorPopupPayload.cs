namespace SocialDemo.Code.Views.ErrorPopup.Payload
{
    public class ErrorPopupPayload : IErrorPopupPayload
    {
        public string Message { get; }
        public float BackgroundTransparency { get; }

        public ErrorPopupPayload(string message, float backgroundTransparency)
        {
            Message = message;
            BackgroundTransparency = backgroundTransparency;
        }
    }
}