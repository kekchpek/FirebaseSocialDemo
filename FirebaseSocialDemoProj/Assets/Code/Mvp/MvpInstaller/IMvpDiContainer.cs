using SocialDemo.Code.Mvp.Model;
using SocialDemo.Code.Mvp.Presenter;
using SocialDemo.Code.Mvp.View;
using UnityEngine;

namespace SocialDemo.Code.Mvp.MvpInstaller
{
    public interface IMvpDiContainer : IPresenterProvider
    {
        void BindView<TInterface, TImplementation>(GameObject prefab) 
            where TImplementation : class, TInterface
            where TInterface : IView;

        void BindPresenter<TImplementation>()
            where TImplementation : class;
        
        void BindModel<TInterface, TImplementation>() 
            where TImplementation : class, TInterface
            where TInterface : IModel;
    }
}