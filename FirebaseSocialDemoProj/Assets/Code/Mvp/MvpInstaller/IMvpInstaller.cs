using SocialDemo.Code.Mvp.Model;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;
using UnityEngine;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    public interface IMvpInstaller
    {
        void InstallView<TInterface, TImplementation>(GameObject prefab) 
            where TImplementation : class, TInterface
            where TInterface : IView;
        
        void InstallPresenter<TInterface, TImplementation>() 
            where TImplementation : class, TInterface
            where TInterface : IPresenter;
        
        void InstallModel<TInterface, TImplementation>() 
            where TImplementation : class, TInterface
            where TInterface : IModel;
    }
}