using System;
using SocialDemo.Code.Mvp.View;

namespace SocialDemo.Code.Mvp.ViewManager
{
    public interface IViewDefinition
    {
        Type PresenterType { get; }
        ViewType ViewType { get; }
    }
}