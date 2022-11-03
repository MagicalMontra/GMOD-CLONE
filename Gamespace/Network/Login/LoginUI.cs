using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Gamespace.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gamespace.Network.Login
{
    public class LoginUI : MonoBehaviour, ILoginUI
    {
        private bool _isEnabled;
        private bool _isRemembered;
        private bool _isAutoLoginEnabled;
        private Regex _emailValidate = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

        [Inject] private SignalBus _signalBus;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private ExtendedToggle _rememberToggle;
        [SerializeField] private ExtendedToggle _autoLoginToggle;
        [SerializeField] private ExtendedButton _loginButton;
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private TMP_InputField _passwordField;

        public void OnCreate(bool isRemembered, string email, Camera uiCamera)
        {
            _canvas.worldCamera = uiCamera;
            _isRemembered = isRemembered;
            _emailField.text = email;
            _passwordField.text = "";
            _rememberToggle.SetActive(_isRemembered);
            _autoLoginToggle.SetActive(_isAutoLoginEnabled);
            _loginButton.onClick.RemoveAllListeners();
            _loginButton.onClick.AddListener(() => _signalBus.AbstractFire(new LoginRequestSignal(_autoLoginToggle.IsTick, _rememberToggle.IsTick, GetFieldData())));
        }
        public void SetActive(bool enabled)
        {
            gameObject.SetActive(enabled);
        }
        private LoginRequestData GetFieldData()
        {
            var data = new LoginRequestData();
            data.email = _emailField.text;
            data.password = _passwordField.text;
            return data;
        }
        private void FixedUpdate()
        {
            _isEnabled = !string.IsNullOrEmpty(_emailField.text) && !string.IsNullOrEmpty(_passwordField.text) && _emailValidate.IsMatch(_emailField.text);
            
            if (_isEnabled != _loginButton.isInteractable)
                _loginButton.isInteractable = _isEnabled;
        }
    }
}