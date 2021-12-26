using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SocialDemo.Code.Views.ErrorPopup.View
{
    public class ErrorPopupView : Mvp.View.View, IErrorPopupView
    {
        [SerializeField] private TMP_Text _messageText;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Button _closeButton;
        
        
        public string Message { get => _messageText.text; set => _messageText.text = value; }

        public float BackgroundTransparency
        {
            get => 1f - _backgroundImage.color.a;
            set =>
                _backgroundImage.color = new Color(
                    _backgroundImage.color.r,
                    _backgroundImage.color.g,
                    _backgroundImage.color.b,
                    1f - value);
        }
        public event Action CloseClicked;

        private void Awake()
        {
            _closeButton.onClick.AddListener(() => CloseClicked?.Invoke());
        }
    }
}