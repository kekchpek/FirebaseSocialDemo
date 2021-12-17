using NUnit.Framework;
using SocialDemo.Code.Mvp.ViewManager;

namespace SocialDemo.Tests.Code.Tests.EditMode.Mvp
{
    public class ViewDefinitionTests
    {
        [Test]
        public void Creation_PresenterTypeSet()
        {
            // Arrange
            var presenterType = typeof(ViewDefinitionTests);
            var viewDef = new ViewDefinition(presenterType);
            
            // Act 
            // no act
            
            // Arrange
            Assert.AreEqual(presenterType, viewDef.PresenterType);
        }
    }
}