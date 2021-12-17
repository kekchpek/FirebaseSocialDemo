using System;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public class ViewDefinition : IViewDefinition
    {
        public ViewDefinition(Type presenterType)
        {
            PresenterType = presenterType;
        }

        public Type PresenterType { get; }
    }
}