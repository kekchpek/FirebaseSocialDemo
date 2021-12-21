using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SocialDemo.Code.Views.LoadingPopup.View
{
    public class LoadingPopupView : Mvp.View.View, ILoadingPopupView
    {

        [SerializeField] private Image _backgroundImage;
        [SerializeField] private TMP_Text _loadingTitleText;
        
        public string LoadingTitle { 
            get => _loadingTitleText.text;
            set => _loadingTitleText.text = value;
        }

        public float BackgroundTransparency
        {
            get => 1f - _backgroundImage.color.a;
            set =>
                _backgroundImage.color = 
                    new Color(1f, 1f, 1f, 1f - value);
        }
    }
}