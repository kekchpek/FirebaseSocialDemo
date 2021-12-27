using System;
using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Domain;
using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Tests.EditMode.TestUtils;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.SignIn;
using SocialDemo.Code.Views.SignIn.View;

namespace SocialDemo.Code.Tests.EditMode.Views.SignInView
{
    public class SignInPresenterTests
    {

        private SignInPresenter CreatePresenter(out ISignInView signInVew,
            out ISignInModel signInModel,
            out IViewManager viewManager)
        {
            signInVew = Substitute.For<ISignInView>();
            signInModel = Substitute.For<ISignInModel>();
            viewManager = Substitute.For<IViewManager>();
            return new SignInPresenter(signInVew, signInModel, viewManager);
        }

        [Test]
        public void GoogleLogin_ButtonClicked_AuthModelGoogleSignedIn()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager);
            
            // Act 
            presenter.Initialize(null);
            signInVew.LoginGoogleClicked += Raise.Event<Action>();
            
            // Assert
            signInModel.ReceivedWithAnyArgs(1).SignInWithGoogle();
        }

        [Test]
        public void GoogleLogin_PromiseFailed_ErrorShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager);
            var promise = TestPromisesStaticFactory.CreatePromise<string>(
                out var successCallbacksRef,
                out var errorCallbacksRef,
                out var finallyCallbacksRef);
            signInModel.SignInWithGoogle().Returns(promise);
            var errorMessage = "Test error message";
            var testError = new Exception(errorMessage);
            
            // Act
            presenter.Initialize(null);
            signInVew.LoginGoogleClicked += Raise.Event<Action>();
            if (errorCallbacksRef.TryGetTarget(out var errorCallbacks))
            {
                foreach (var callback in errorCallbacks)
                {
                    callback?.Invoke(testError);
                }
            }
            
            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.ErrorPopup, Arg.Is<IErrorPopupPayload>(x => x.Message == errorMessage));
        }

        [Test]
        public void Login_PromiseFailed_ErrorShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager);
            signInVew.Login.Returns("SomeLogin");
            signInVew.Password.Returns("SomePass");
            
            // Act 
            presenter.Initialize(null);
            signInVew.LoginClicked += Raise.Event<Action>();
            
            // Assert
            signInModel.Received(1).SignIn(signInVew.Login, signInVew.Password);
        }

        [Test]
        public void Login_ButtonClicked_AuthModelSignedIn()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager);
            var promise = TestPromisesStaticFactory.CreatePromise<string>(
                out var successCallbacksRef,
                out var errorCallbacksRef,
                out var finallyCallbacksRef);
            signInModel.SignIn(Arg.Any<string>(), Arg.Any<string>()).Returns(promise);
            var errorMessage = "Test error message";
            var testError = new Exception(errorMessage);
            
            // Act
            presenter.Initialize(null);
            signInVew.LoginGoogleClicked += Raise.Event<Action>();
            if (errorCallbacksRef.TryGetTarget(out var errorCallbacks))
            {
                foreach (var callback in errorCallbacks)
                {
                    callback?.Invoke(testError);
                }
            }
            
            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.ErrorPopup, Arg.Is<IErrorPopupPayload>(x => x.Message == errorMessage));
        }
        
    }
}