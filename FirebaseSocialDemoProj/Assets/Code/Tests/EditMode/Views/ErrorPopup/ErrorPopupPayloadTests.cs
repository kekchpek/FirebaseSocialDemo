using NUnit.Framework;
using SocialDemo.Code.Views.ErrorPopup.Payload;

namespace SocialDemo.Code.Tests.EditMode.Views.ErrorPopup
{
    public class ErrorPopupPayloadTests
    {
        [Test]
        public void Creation_MessageSet()
        {
            // Arrange
            const string message = "randomString";
            var payload = new ErrorPopupPayload(message, default);

            // Act
            // no Act
            
            // Assert
            Assert.AreEqual(message, payload.Message);
        }
        
        [Test]
        public void Creation_BackgroundTransparencySet()
        {
            // Arrange
            const float backgroundTransparency = 0.12345f;
            var payload = new ErrorPopupPayload(default, backgroundTransparency);

            // Act
            // no Act
            
            // Assert
            Assert.AreEqual(backgroundTransparency, payload.BackgroundTransparency);
        }
    }
}