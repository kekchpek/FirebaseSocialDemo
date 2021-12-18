using NSubstitute;
using NUnit.Framework;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Tests.EditMode.Mvp
{
    public class PresenterTests
    {

        private class TestPresenter : Presenter<IView, IPresenterPayload>
        {
            public IView TestView => View;
            
            public TestPresenter(IView view) : base(view)
            {
            }
        }

        private TestPresenter CreatePresenter(out IView view)
        {
            view = Substitute.For<IView>();
            return new TestPresenter(view);
        }

        [Test]
        public void Creation_ViewSet()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);
            
            // Act
            // no act
            
            // Assert
            Assert.AreEqual(view, presenter.TestView);
        }

        [Test]
        public void Dispose_ViewClosed()
        {
            // Arrange
            var presenter = CreatePresenter(out var view);
            
            // Act
            presenter.Dispose();
            
            // Assert
            view.ReceivedWithAnyArgs().Close();
        }
    }
}