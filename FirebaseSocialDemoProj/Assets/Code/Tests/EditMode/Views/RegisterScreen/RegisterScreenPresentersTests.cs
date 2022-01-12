using System;
using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Auxiliary.Exceptions;
using SocialDemo.Code.Domain;
using SocialDemo.Code.Mvp.ViewManager;
using SocialDemo.Code.Tests.EditMode.TestUtils;
using SocialDemo.Code.Views.ErrorPopup.Payload;
using SocialDemo.Code.Views.RegisterScreen;
using SocialDemo.Code.Views.RegisterScreen.View;

namespace SocialDemo.Code.Tests.EditMode.Views.RegisterScreen
{
    public class RegisterScreenPresentersTests
    {

        private RegisterScreenPresenter CreatePresenter(out IRegisterScreenView view,
            out IViewManager viewManager,
            out ISignInModel signInModel)
        {
            view = Substitute.For<IRegisterScreenView>();
            viewManager = Substitute.For<IViewManager>();
            signInModel = Substitute.For<ISignInModel>();
            return new RegisterScreenPresenter(view, viewManager, signInModel);
        }
        
        [Test]
        public void RegisterClicked_EmailsMismatch_ErrorShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var view, 
                out var viewManager,
                out var signInModel);
            view.Email.Returns("one");
            view.ConfirmedEmail.Returns("two");

            // Act
            presenter.Initialize(null);
            view.RegisterClicked += Raise.Event<Action>();

            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.ErrorPopup, 
                Arg.Is<IErrorPopupPayload>(x => x.Message == EmailConfirmMismatchException.ErrorMessage));
        }
        
        [Test]
        public void RegisterClicked_PasswordsMismatch_ErrorShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var view, 
                out var viewManager,
                out var signInModel);
            view.Password.Returns("one");
            view.ConfirmedPassword.Returns("two");

            // Act
            presenter.Initialize(null);
            view.RegisterClicked += Raise.Event<Action>();

            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.ErrorPopup, 
                Arg.Is<IErrorPopupPayload>(x => x.Message == PasswordConfirmMismatchException.ErrorMessage));
        }

        [Test]
        public void RegisterClicked_AllMatched_RegisterCalled()
        {
            // Arrange
            var presenter = CreatePresenter(out var view, 
                out var viewManager,
                out var signInModel);
            view.Email.Returns("email");
            view.ConfirmedEmail.Returns("email");
            view.Password.Returns("pass");
            view.ConfirmedPassword.Returns("pass");
            
            // Act
            presenter.Initialize(null);
            view.RegisterClicked += Raise.Event<Action>();

            // Assert
            signInModel.Received(1).CreateNewUser(view.Email, view.Password);
        }

        [Test]
        public void RegisterClicked_RegisterError_ErrorShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var view, 
                out var viewManager,
                out var signInModel);
            
            view.Email.Returns("email");
            view.ConfirmedEmail.Returns("email");
            view.Password.Returns("pass");
            view.ConfirmedPassword.Returns("pass");

            var registerPromise = TestPromisesStaticFactory.CreatePromise(
                out var successCallbacksRef,
                out var errorCallbacksRef,
                out var finallyCallbacksRef);
            signInModel.CreateNewUser(default, default).ReturnsForAnyArgs(registerPromise);
            
            var errorMessage = "test error message";
            var error = new Exception(errorMessage);
            
            // Act
            presenter.Initialize(null);
            view.RegisterClicked += Raise.Event<Action>();
            if (errorCallbacksRef.TryGetTarget(out var errorsCallbacks))
            {
                foreach (var callback in errorsCallbacks)
                {
                    callback?.Invoke(error);
                }
            }

            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.ErrorPopup, 
                Arg.Is<IErrorPopupPayload>(x => x.Message == errorMessage));
        }

        [Test]
        public void RegisterClicked_RegisterSuccess_SuccessLayoutShown()
        {
            // Arrange
            var presenter = CreatePresenter(out var view, 
                out var viewManager,
                out var signInModel);
            
            view.Email.Returns("email");
            view.ConfirmedEmail.Returns("email");
            view.Password.Returns("pass");
            view.ConfirmedPassword.Returns("pass");

            var registerPromise = TestPromisesStaticFactory.CreatePromise(
                out var successCallbacksRef,
                out var errorCallbacksRef,
                out var finallyCallbacksRef);
            signInModel.CreateNewUser(default, default).ReturnsForAnyArgs(registerPromise);
            
            // Act
            presenter.Initialize(null);
            view.RegisterClicked += Raise.Event<Action>();
            if (successCallbacksRef.TryGetTarget(out var successCallbacks))
            {
                foreach (var callback in successCallbacks)
                {
                    callback?.Invoke();
                }
            }

            // Assert
            view.Received(1).ShowSuccessLayout();
        }

        [Test]
        public void OkClicked_MovedToSignInScreen()
        {
            // Arrange
            var presenter = CreatePresenter(out var view, 
                out var viewManager,
                out var signInModel);
            
            // Act
            presenter.Initialize(null);
            view.RegistrationSuccessOkClicked += Raise.Event<Action>();

            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.SignIn);
        }

        [Test]
        public void BackClicked_MovedToSignInScreen()
        {
            // Arrange
            var presenter = CreatePresenter(out var view, 
                out var viewManager,
                out var signInModel);
            
            // Act
            presenter.Initialize(null);
            view.BackClicked += Raise.Event<Action>();

            // Assert
            viewManager.Received(1).OpenView(ViewDefinitions.SignIn);
        }
    }
}