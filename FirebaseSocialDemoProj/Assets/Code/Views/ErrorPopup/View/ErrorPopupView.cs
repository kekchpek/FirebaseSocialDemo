using System;
using UnityEngine;

namespace SocialDemo.Code.Views.ErrorPopup.View
{
    public class ErrorPopupView : Mvp.View.View, IErrorPopupView
    {
        public string Message { get; set; }
        public float BackgroundTransparency { get; set; }
        public event Action CloseClicked;
    }
}