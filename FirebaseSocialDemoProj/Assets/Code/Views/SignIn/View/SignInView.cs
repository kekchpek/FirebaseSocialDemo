using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SocialDemo.Code.Views.SignIn.View
{
    public class SignInView : Mvp.View.View, ISignInView
    {
        [SerializeField] private Button _loginButton;
        [SerializeField] private TMP_InputField _loginInputField;
        [SerializeField] private TMP_InputField _passwordInputField;

        private void Awake()
        {
            _loginButton.onClick.AddListener(()=> LoginClicked?.Invoke());
        }

        public string Login => _loginInputField.text;
        public string Password => _passwordInputField.text;
        public event Action LoginClicked;
    }
}