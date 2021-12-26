using System;
using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Views.ErrorPopup;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.ErrorPopup.View;

namespace SocialDemo.Code.Tests.EditMode.Views.ErrorPopup
{
    public class ErrorPopupPresenterTests
    {

        private ErrorPopupPresenter CreatePresenter(out IErrorPopupView view)
        {
            view = Substitute.For<IErrorPopupView>();
            return new ErrorPopupPresenter(view);
        }
        
        [Test]
        public void Initialization_PayloadMessage_SetToView()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);
            var payload = Substitute.For<IErrorPopupPayload>();
            payload.Message.Returns("someString");

            // Act
            presenter.Initialize(payload);
            
            // Assert
            view.Received(1).Message = payload.Message;
        }
        
        [Test]
        public void Initialization_PayloadBackgroundTransparency_SetToView()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);
            var payload = Substitute.For<IErrorPopupPayload>();
            payload.BackgroundTransparency.Returns(0.12345f);

            // Act
            presenter.Initialize(payload);
            
            // Assert
            view.Received(1).BackgroundTransparency = payload.BackgroundTransparency;
        }
        
        [Test]
        public void View_CloseEvent_ViewClosed()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);

            // Act
            presenter.Initialize(Substitute.For<IErrorPopupPayload>());
            view.CloseClicked += Raise.Event<Action>();
            
            // Assert
            view.ReceivedWithAnyArgs().Close();
        }
    }
}