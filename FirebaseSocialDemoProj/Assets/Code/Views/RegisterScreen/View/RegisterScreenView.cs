using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SocialDemo.Code.Views.RegisterScreen.View
{
    public class RegisterScreenView : Mvp.View.View, IRegisterScreenView
    {

        [SerializeField] private TMP_InputField _emailInputField;
        [SerializeField] private TMP_InputField _confirmedEmailInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private TMP_InputField _confirmedPasswordInputField;

        [SerializeField] private Button _registerButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _successOkButton;

        [SerializeField] private GameObject _registerLayout;
        [SerializeField] private GameObject _successLayout;

        public string Email => _emailInputField.text;
        public string ConfirmedEmail => _confirmedEmailInputField.text;
        public string Password => _passwordInputField.text;
        public string ConfirmedPassword => _confirmedPasswordInputField.text;
        
        public event Action RegisterClicked;
        public event Action RegistrationSuccessOkClicked;
        public event Action BackClicked;

        private void Awake()
        {
            _registerButton.onClick.AddListener(() => RegisterClicked?.Invoke());
            _backButton.onClick.AddListener(() => BackClicked?.Invoke());
            _successOkButton.onClick.AddListener(() => RegistrationSuccessOkClicked?.Invoke());
        }


        public void ShowSuccessLayout()
        {
            _registerLayout.SetActive(false);
            _successLayout.SetActive(true);
        }
    }
}