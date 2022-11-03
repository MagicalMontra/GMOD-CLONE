using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gamespace.Localization;
using TMPro;
using Zenject;
using UnityEngine;
using Gamespace.UI;
using Gamespace.Utilis;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Gamespace.Network.Register
{
    public class RegisterUI : MonoBehaviour, IRegisterUI
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private TranslatorFacade _translator;
        
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Color _weakColor;
        [SerializeField] private Color _mediumColor;
        [SerializeField] private Color _strongColor;
        [SerializeField] private ExtendedButton _backButton;
        [SerializeField] private ExtendedButton _nextButton;
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private ExtendedButton _closeButton;
        [SerializeField] private TMP_InputField _mobileField;
        [SerializeField] private TMP_InputField _lastNameField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private Image _passwordIntegrityImage;
        [SerializeField] private TMP_InputField _firstNameField;
        [SerializeField] private TMP_InputField _confirmPasswordField;
        [SerializeField] private List<GameObject> _pageDots = new List<GameObject>();
        [SerializeField] private UIAnimationFacade _transitAnimation;
        [SerializeField] private List<UIAnimationFacade> _pageAnimitions = new List<UIAnimationFacade>();
        [SerializeField] private List<RectTransform> _pages = new List<RectTransform>();
        
        private int _pageCounter;
        private Action _closeAction = null;
        private Regex _emailValidate = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

        public void OnCreate(Camera uiCamera, Action closeAction)
        {
            if (closeAction != null)
                _closeAction = closeAction;
            
            _canvas.worldCamera = uiCamera;
            _nextButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _closeButton.onClick.RemoveAllListeners();
            _nextButton.onClick.AddListener(OnNextButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _closeButton.onClick.AddListener(() => SetActive(false));
            _transitAnimation.Function?.inComplete.RemoveAllListeners();
            _transitAnimation.Function?.inComplete.AddListener(() =>
            {
                _pageCounter = 0;
                for (int i = 0; i < _pageDots.Count; i++)
                    _pageDots[i].SetActive(i == _pageCounter);

                _pages[0].localPosition = Vector3.zero;
                _pageAnimitions[0].Behaviour?.On().Forget();
            });
            _transitAnimation.Function?.outComplete.RemoveAllListeners();
            _transitAnimation.Function?.outComplete.AddListener(() =>
            {
                _closeAction?.Invoke();
                gameObject.SetActive(false);
            });
            
            _passwordField.onValueChanged.AddListener(IntegrityColorHandle);
            _confirmPasswordField.onValueChanged.AddListener(IntegrityColorHandle);
            
            _backButton.gameObject.SetActive(false);
            _passwordIntegrityImage.gameObject.SetActive(false);

            _emailField.text = "";
            _passwordField.text = "";
            _confirmPasswordField.text = "";
            _firstNameField.text = "";
            _lastNameField.text = "";
            _mobileField.text = "";
        }
        public void SetActive(bool enabled)
        {
            if (enabled)
            {
                gameObject.SetActive(true);
                _transitAnimation.Behaviour?.On().Forget();
            }
            else
            {
                _transitAnimation.Behaviour?.Off().Forget();

                for (int i = 0; i < _pageAnimitions.Count; i++)
                    _pageAnimitions[i].Behaviour?.Off().Forget();
            }
        }
        private void IntegrityColorHandle(string value)
        {
            if (_pageCounter > 0)
                return;
            
            var passwordIsNotEmpty = !string.IsNullOrEmpty(_passwordField.text);
            var confirmPasswordIsNotEmpty = !string.IsNullOrEmpty(_passwordField.text);
            var passwordMatch = _passwordField.text == _confirmPasswordField.text;
                
            _passwordIntegrityImage.gameObject.SetActive(passwordIsNotEmpty && confirmPasswordIsNotEmpty && passwordMatch);
            var passIntegrityValue = PasswordValidator.Value(_passwordField.text);

            if (passIntegrityValue <= 0.4f)
                _passwordIntegrityImage.color = _weakColor;
            else if (passIntegrityValue <= 0.6f)
                _passwordIntegrityImage.color = _mediumColor;
            else
                _passwordIntegrityImage.color = _strongColor;
        }
        private void OnBackButtonClicked()
        {
            if (_pageCounter > 0)
                PageChange(-1).Forget();
        }
        private void OnNextButtonClicked()
        {
            if (_pageCounter < _pageDots.Count - 1)
            {
                PageChange(1).Forget();
                return;
            }
            
            var emailIsNotEmpty = !string.IsNullOrEmpty(_emailField.text);
            var passwordIsNotEmpty = !string.IsNullOrEmpty(_passwordField.text);
            var confirmPasswordIsNotEmpty = !string.IsNullOrEmpty(_passwordField.text);
            var passwordMatch = _passwordField.text == _confirmPasswordField.text;
            var mobileIsNotEmpty = !string.IsNullOrEmpty(_mobileField.text);
            var firstNameIsNotEmpty = !string.IsNullOrEmpty(_firstNameField.text);
            var lastNameIsNotEmpty = !string.IsNullOrEmpty(_lastNameField.text);
            var isEmailCorrect = _emailValidate.IsMatch(_emailField.text);

            if (!emailIsNotEmpty)
            {
                _translator.Translate("Register", "emailEmpty", (emailEmpty) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", emailEmpty, "Dismiss", () => PageChange(-1).Forget()));
                });
                return;
            }

            if (!passwordIsNotEmpty)
            {
                _translator.Translate("Register", "passwordEmpty", (passwordEmpty) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", passwordEmpty, "Dismiss", () => PageChange(-1).Forget()));
                });
                return;
            }

            if (!confirmPasswordIsNotEmpty)
            {
                _translator.Translate("Register", "confirmPasswordEmpty", (confirmPasswordEmpty) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", confirmPasswordEmpty, "Dismiss", () => PageChange(-1).Forget()));
                });
                return;
            }

            if (!firstNameIsNotEmpty)
            {
                _translator.Translate("Register", "firstNameEmpty", (firstNameEmpty) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", firstNameEmpty, "Dismiss"));
                });
                return;
            }

            if (!lastNameIsNotEmpty)
            {
                _translator.Translate("Register", "lastNameEmpty", (lastNameEmpty) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", lastNameEmpty, "Dismiss"));
                });
                return;
            }
            
            if (!mobileIsNotEmpty)
            {
                _translator.Translate("Register", "mobileEmpty", (mobileEmpty) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", mobileEmpty, "Dismiss"));
                });
                return;
            }

            if (!passwordMatch)
            {
                _translator.Translate("Register", "passwordMismatch", (passwordMismatch) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", passwordMismatch, "Dismiss", () => PageChange(-1).Forget()));
                });
                return;
            }

            if (!isEmailCorrect)
            {
                _translator.Translate("Register", "emailIncorrect", (emailIncorrect) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", emailIncorrect, "Dismiss", () => PageChange(-1).Forget()));
                });
                return;
            }
            
            var passIntegrityValue = PasswordValidator.Value(_passwordField.text);
            var isPasswordStrongEnough = passIntegrityValue > PasswordValidator.Validate(PasswordValidator.PasswordScore.Medium);

            if (!isPasswordStrongEnough)
            {
                _translator.Translate("Register", "weakPasswordSubmit", (weakPasswordSubmit) =>
                {
                    _signalBus.Fire(new NotificationRequestSignal("Error", weakPasswordSubmit, "Dismiss", () => PageChange(-1).Forget()));
                });
                return;
            }
            
            _signalBus.AbstractFire(new RegisterRequestSignal(GetRegisterData()));
        }
        private RegisterRequestData GetRegisterData()
        {
            var data = new RegisterRequestData
            {
                email = _emailField.text,
                firstname = _firstNameField.text,
                lastname = _lastNameField.text,
                password = _passwordField.text,
                mobile = _mobileField.text
            };
            return data;
        }
        private async UniTaskVoid PageChange(int value)
        {
            if (_pageCounter + value > _pageDots.Count - 1)
                return;
            
            if (_pageCounter + value < 0)
                return;
            
            _pageCounter += value;

            for (int i = 0; i < _pageDots.Count; i++)
                _pageDots[i].SetActive(i == _pageCounter);

            var posValue = value < 0 ? -575 : 575;
            
            for (int i = 0; i < _pageAnimitions.Count; i++)
            {
                if (i != _pageCounter)
                {
                    _pageAnimitions[i].Behaviour?.Off().Forget();
                    _pages[i].DOLocalMoveX(-posValue, _pageAnimitions[i].Behaviour.Duration).Play();
                }
            }

            // await UniTask.Delay(Mathf.CeilToInt(_pageAnimitions[_pageCounter].Behaviour.Duration * 1000));
            _pages[_pageCounter].localPosition = new Vector3(posValue, _pages[_pageCounter].localPosition.y, _pages[_pageCounter].localPosition.z);
            _pages[_pageCounter].DOLocalMoveX(0, _pageAnimitions[_pageCounter].Behaviour.Duration).Play();
            _pageAnimitions[_pageCounter].Behaviour?.On().Forget();

            _backButton.gameObject.SetActive(_pageCounter > 0);
            
            await UniTask.Yield();
        }
    }
}