using System;
using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Auxiliary.Trigger;
using SocialDemo.Code.Auxiliary.Trigger.Factory;
using SocialDemo.Code.Domain;
using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Tests.EditMode.TestUtils;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.LoadingPopup.Payload;
using SocialDemo.Code.Views.SignIn;
using SocialDemo.Code.Views.SignIn.View;

namespace SocialDemo.Code.Tests.EditMode.Views.SignInView
{
    public class SignInPresenterTests
    {

        private SignInPresenter CreatePresenter(out ISignInView signInVew,
            out ISignInModel signInModel,
            out IViewManager viewManager,
            out ITriggerFactory triggerFactory)
        {
            signInVew = Substitute.For<ISignInView>();
            signInModel = Substitute.For<ISignInModel>();
            viewManager = Substitute.For<IViewManager>();
            triggerFactory = Substitute.For<ITriggerFactory>();
            return new SignInPresenter(signInVew, signInModel, viewManager, triggerFactory);
        }

        [Test]
        public void GoogleLogin_ButtonClicked_AuthModelGoogleSignedIn()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager,
                out var triggerFactory);
            
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
                out var viewManager,
                out var triggerFactory);
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
        public void Login_ButtonClicked_AuthModelSignedIn()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager,
                out var triggerFactory);
            signInVew.Login.Returns("SomeLogin");
            signInVew.Password.Returns("SomePass");
            
            // Act 
            presenter.Initialize(null);
            signInVew.LoginClicked += Raise.Event<Action>();
            
            // Assert
            signInModel.Received(1).SignIn(signInVew.Login, signInVew.Password);
        }

        [Test]
        public void Login_PromiseFailed_ErrorShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager,
                out var triggerFactory);
            var promise = TestPromisesStaticFactory.CreatePromise<string>(
                out var successCallbacksRef,
                out var errorCallbacksRef,
                out var finallyCallbacksRef);
            signInModel.SignIn(Arg.Any<string>(), Arg.Any<string>()).Returns(promise);
            var errorMessage = "Test error message";
            var testError = new Exception(errorMessage);
            
            // Act
            presenter.Initialize(null);
            signInVew.LoginClicked += Raise.Event<Action>();
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
        public void SignIn_ButtonClicked_LoadingShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager,
                out var triggerFactory);
            var trigger = Substitute.For<IRegularTrigger>();
            triggerFactory.CreateRegularTrigger().Returns(trigger);
            
            // Act 
            presenter.Initialize(null);
            signInVew.LoginClicked += Raise.Event<Action>();
            
            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.LoadingPopup, 
                Arg.Is<ILoadingPopupPayload>(x => x.CloseTrigger == trigger));
        }

        [Test]
        public void SignIn_PromiseCompleted_LoadingHidden()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager,
                out var triggerFactory);

            var trigger = Substitute.For<IRegularTrigger>();
            triggerFactory.CreateRegularTrigger().Returns(trigger);

            var signInPromise = TestPromisesStaticFactory.CreatePromise<string>(out var successCallbacksRef,
                out var errorCallbacksRef,
                out var finallyCallbacksRef);
            signInModel.SignIn(default, default).ReturnsForAnyArgs(signInPromise);
            
            // Act 
            presenter.Initialize(null);
            signInVew.LoginClicked += Raise.Event<Action>();
            if (finallyCallbacksRef.TryGetTarget(out var finallyCallbacks))
            {
                foreach (var callback in finallyCallbacks)
                {
                    callback?.Invoke();
                }
            }
            
            // Assert
            trigger.Received().Trigger();
        }

        [Test]
        public void RegisterClicked_RegisterScreen_Opened()
        {
            // Arrange
            var presenter = CreatePresenter(out var signInVew,
                out var signInModel,
                out var viewManager,
                out var triggerFactory);
            
            // Act 
            presenter.Initialize(null);
            signInVew.RegisterClicked += Raise.Event<Action>();
            
            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.RegisterScreen);
        }
        
    }
}