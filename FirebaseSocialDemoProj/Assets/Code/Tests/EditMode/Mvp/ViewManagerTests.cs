using System;
using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Mvp.MvpInstaller;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;
using SocialDemo.Code.Mvp.ViewManager;

namespace SocialDemo.Code.Tests.EditMode.Mvp
{
    public class ViewManagerTests
    {

        private class TestPresenterClass : IPresenter
        {
            public void Initialize(IPresenterPayload presenterPayload)
            {
            }

            public void Dispose()
            {
            }
        }

        private Type PresenterType => typeof(TestPresenterClass);
        
        private IViewManager createViewManager(out IPresenterProvider presenterProvider)
        {
            presenterProvider = Substitute.For<IPresenterProvider>();
            return new ViewManager(presenterProvider);
        }
        
        [TestCase(ViewType.Screen)]
        [TestCase(ViewType.Popup)]
        public void OpenView_PresenterObtained(ViewType viewType)
        {
            // Arrange
            var viewManager = createViewManager(
                out var presenterProvider);
            var viewDef = Substitute.For<IViewDefinition>();
            viewDef.PresenterType.Returns(PresenterType);
            viewDef.ViewType.Returns(viewType);
            
            // Act
            viewManager.OpenView(viewDef);

            // Assert
            presenterProvider.Received().Obtain(PresenterType);
        }
        
        [Test]
        public void OpenView_NoPayload_PresenterInitialized()
        {
            // Arrange
            var viewManager = createViewManager(
                out var presenterProvider);
            var presenter = Substitute.For<IPresenter>();
            presenterProvider.Obtain(PresenterType).Returns(presenter);
            var viewDef = Substitute.For<IViewDefinition>();
            viewDef.PresenterType.Returns(PresenterType);
            
            // Act
            viewManager.OpenView(viewDef);

            // Assert
            presenter.Received(1).Initialize();
        }
        
        [Test]
        public void OpenView_HasPayload_PresenterInitialized()
        {
            // Arrange
            var viewManager = createViewManager(
                out var presenterProvider);
            var presenter = Substitute.For<IPresenter>();
            presenterProvider.Obtain(PresenterType).Returns(presenter);
            var viewDef = Substitute.For<IViewDefinition>();
            viewDef.PresenterType.Returns(PresenterType);
            var payload = Substitute.For<IPresenterPayload>();
            
            // Act
            viewManager.OpenView(viewDef, payload);

            // Assert
            presenter.Received(1).Initialize(payload);
        }
        
        [Test]
        public void OpenView_TwoScreens_PresenterDisposed()
        {
            // Arrange
            var viewManager = createViewManager(
                out var presenterProvider);
            var presenter = Substitute.For<IPresenter>();
            presenterProvider.Obtain(PresenterType).Returns(presenter);
            var viewDef = Substitute.For<IViewDefinition>();
            viewDef.PresenterType.Returns(PresenterType);
            viewDef.ViewType.Returns(ViewType.Screen);
            
            // Act
            viewManager.OpenView(viewDef);
            viewManager.OpenView(viewDef);

            // Assert
            presenter.ReceivedWithAnyArgs(1).Dispose();
        }
        
        [Test]
        public void OpenView_TwoPopups_PresenterNotDisposed()
        {
            // Arrange
            var viewManager = createViewManager(
                out var presenterProvider);
            var presenter = Substitute.For<IPresenter>();
            presenterProvider.Obtain(PresenterType).Returns(presenter);
            var viewDef = Substitute.For<IViewDefinition>();
            viewDef.PresenterType.Returns(PresenterType);
            viewDef.ViewType.Returns(ViewType.Popup);
            
            // Act
            viewManager.OpenView(viewDef);
            viewManager.OpenView(viewDef);

            // Assert
            presenter.DidNotReceiveWithAnyArgs().Dispose();
        }
        
    }
}