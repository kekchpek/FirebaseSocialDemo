using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public class ViewDefinition : IViewDefinition
    {
        public ViewDefinition(Type presenterType, ViewType viewType)
        {
            PresenterType = presenterType;
            ViewType = viewType;
        }

        public Type PresenterType { get; }
        public ViewType ViewType { get; }
    }
}