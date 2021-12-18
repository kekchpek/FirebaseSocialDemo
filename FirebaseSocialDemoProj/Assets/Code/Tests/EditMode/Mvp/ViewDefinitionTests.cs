using System;
using NUnit.Framework;
using SocialDemo.Code.Mvp.View;
using SocialDemo.Code.Mvp.ViewManager;

namespace SocialDemo.Code.Tests.EditMode.Mvp
{
    public class ViewDefinitionTests
    {
        [Test]
        public void Creation_PresenterTypeSet()
        {
            // Arrange
            var presenterType = typeof(ViewDefinitionTests);
            var viewDef = new ViewDefinition(presenterType, ViewType.Popup);
            
            // Act 
            // no act
            
            // Arrange
            Assert.AreEqual(presenterType, viewDef.PresenterType);
        }
        
        [Test]
        public void Creation_ViewTypeSet()
        {
            foreach (ViewType viewType in Enum.GetValues(typeof(ViewType)))
            {
                // Arrange
                var presenterType = typeof(ViewDefinitionTests);
                var viewDef = new ViewDefinition(presenterType, viewType);
            
                // Act 
                // no act
            
                // Arrange
                Assert.AreEqual(viewType, viewDef.ViewType);
            }
        }
    }
}