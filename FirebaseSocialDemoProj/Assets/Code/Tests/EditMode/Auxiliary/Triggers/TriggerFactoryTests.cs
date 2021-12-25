using NUnit.Framework;
using SocialDemo.Code.Auxiliary.Trigger;
using SocialDemo.Code.Auxiliary.Trigger.Factory;

namespace SocialDemo.Code.Tests.EditMode.Auxiliary.Triggers
{
    public class TriggerFactoryTests
    {
        [Test]
        public void CreateRegularTrigger_RegularTriggerCreated()
        {
            // Arrange
            var factory = new TriggerFactory();
            
            // Act
            var regularTrigger = factory.CreateRegularTrigger();
            
            // Assert
            Assert.IsTrue(regularTrigger is RegularTrigger);
        }
    }
}