using System;
using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Views.LoadingPopup;
using SocialDemo.Code.Views.LoadingPopup.Payload;
using SocialDemo.Code.Views.LoadingPopup.View;

namespace SocialDemo.Code.Tests.EditMode.Features.LoadingPopup
{
    public class LoadingPopupPresenterTests
    {

        private LoadingPopupPresenter CreatePresenter(out ILoadingPopupView view)
        {
            view = Substitute.For<ILoadingPopupView>();
            return new LoadingPopupPresenter(view);
        }

        [Test]
        public void Initialization_Title_Set()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);
            var payload = Substitute.For<ILoadingPopupPayload>();
            payload.LoadingTitle.Returns("randomString");
            
            // Act
            presenter.Initialize(payload);
            
            // Assert
            view.Received(1).LoadingTitle = payload.LoadingTitle;
        }

        [Test]
        public void Initialization_Background_Set()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);
            var payload = Substitute.For<ILoadingPopupPayload>();
            payload.BackgroundTransparency.Returns(0.23451f);
            
            // Act
            presenter.Initialize(payload);
            
            // Assert
            view.Received(1).BackgroundTransparency = payload.BackgroundTransparency;
        }

        [Test]
        public void Closing_EventRaised_ViewClosed()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);
            var payload = Substitute.For<ILoadingPopupPayload>();
            
            // Act
            presenter.Initialize(payload);
            payload.CloseTrigger.OnTriggered += Raise.Event<Action>();
            
            // Assert
            view.Received(1).Close();
        }
        
    }
}