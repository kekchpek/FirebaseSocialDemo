using NUnit.Framework;
using SocialDemo.Code.Auxiliary.Trigger;

namespace SocialDemo.Code.Tests.EditMode.Auxiliary.Triggers
{
    public class TriggerTests
    {

        [Test]
        public void Triggered_EventCalled()
        {
            // Arrange
            var trigger = new RegularTrigger();
            
            // Act
            var triggered = 0;
            trigger.OnTriggered += () => triggered++;
            trigger.Trigger();
            
            // Assert
            Assert.AreEqual(1, triggered);
        }
        
    }
}