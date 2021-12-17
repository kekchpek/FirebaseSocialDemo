using System;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public interface IViewDefinition
    {
        Type PresenterType { get; }
    }
}