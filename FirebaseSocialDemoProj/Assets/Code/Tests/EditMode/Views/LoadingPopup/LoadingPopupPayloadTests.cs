using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Auxiliary.Trigger;
using SocialDemo.Code.Views.LoadingPopup.Payload;

namespace SocialDemo.Code.Tests.EditMode.Views.LoadingPopup
{
    public class LoadingPopupPayloadTests
    {
        [Test]
        public void Creation_CloseTrigger_Set()
        {
            // Arrange
            var triggerHandler = Substitute.For<ITriggerHandler>();
            var payload = new LoadingPopupPayload(triggerHandler, default, default);
            
            // Act
            // no act
            
            // Assert
            Assert.AreEqual(triggerHandler, payload.CloseTrigger);
        }
        
        [Test]
        public void Creation_LoadingTitle_Set()
        {
            // Arrange
            const string loadingTitle = "randomString";
            var payload = new LoadingPopupPayload(default, loadingTitle, default);
            
            // Act
            // no act
            
            // Assert
            Assert.AreEqual(loadingTitle, payload.LoadingTitle);
        }
        
        [Test]
        public void Creation_BackgroundTransparency_Set()
        {
            // Arrange
            const float backgroundTransparency = 0.123456f;
            var payload = new LoadingPopupPayload(default, default, backgroundTransparency);
            
            // Act
            // no act
            
            // Assert
            Assert.AreEqual(backgroundTransparency, payload.BackgroundTransparency);
        }
    }
}