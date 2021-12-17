using System;
using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Mvp.MvpInstaller;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.ViewManager;

namespace SocialDemo.Tests.Code.Tests.EditMode.Mvp
{
    public class ViewManagerTests
    {

        private class TestPresenterClass : IPresenter
        {
            public void Dispose()
            {
            }

            public void Initialize()
            {
            }
        }

        private Type PresenterType => typeof(TestPresenterClass);
        
        private IViewManager createViewManager(out IPresenterProvider presenterProvider)
        {
            presenterProvider = Substitute.For<IPresenterProvider>();
            return new ViewManager(presenterProvider);
        }
        
        [Test]
        public void OpenView_PresenterObtained()
        {
            // Arrange
            var viewManager = createViewManager(
                out var presenterProvider);
            var viewDef = Substitute.For<IViewDefinition>();
            viewDef.PresenterType.Returns(PresenterType);
            
            // Act
            viewManager.OpenView(viewDef);

            // Assert
            presenterProvider.Received().Obtain(PresenterType);
        }
        
        [Test]
        public void OpenView_PresenterInitialized()
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
            presenter.ReceivedWithAnyArgs(1).Initialize();
        }
        
        [Test]
        public void OpenView_OpenedTwice_PresenterDisposed()
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
            viewManager.OpenView(viewDef);

            // Assert
            presenter.ReceivedWithAnyArgs(1).Dispose();
        }
        
    }
}