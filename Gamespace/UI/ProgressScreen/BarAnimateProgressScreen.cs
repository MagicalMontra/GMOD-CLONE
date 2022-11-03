using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI.ProgressScreen
{
    public class BarAnimateProgressScreen : MonoBehaviour, IProgressScreen
    {
        [SerializeField] private Slider _bar;
        [SerializeField] private CanvasGroup _fader;
        [SerializeField] private TextMeshProUGUI _progressText;

        private bool _isEnabled;

        private Sequence _barSequence;
        private Sequence _openSequence;
        
        public void Close(string text)
        {
            _barSequence?.Kill();
            _barSequence = DOTween.Sequence();
            _barSequence.Append(DOTween.To(setter => _bar.value = setter, _bar.value, 1f, 0.4f));
            
            if (_isEnabled)
            {
                _openSequence?.Kill();
                _openSequence = DOTween.Sequence();
                _openSequence.AppendCallback(() => _fader.alpha = 1f);
                _openSequence.Append(_fader.DOFade(0, 0.4f));
                _openSequence.AppendCallback(() =>
                {
                    _isEnabled = false;
                    gameObject.SetActive(false);
                });

                _barSequence.Append(_openSequence);
            }
            
            _barSequence.Play();
            _progressText.text = $"{text}";
        }
        public void Show(int current, int total, string text)
        {
            var progress = (float)current / (float)total;

            if (!_isEnabled)
            {
                _openSequence?.Kill();
                _openSequence = DOTween.Sequence();
                _openSequence.AppendCallback(() => _isEnabled = true);
                _openSequence.AppendCallback(() => gameObject.SetActive(true));
                _openSequence.AppendCallback(() => _fader.alpha = 0f);
                _openSequence.Append(_fader.DOFade(1, 0.4f));
                _openSequence.Play();
            }
            
            

            _barSequence?.Kill();
            _barSequence = DOTween.Sequence();
            if (progress < _bar.value)
                _barSequence.AppendCallback(() => _bar.value = progress);
            else
                _barSequence.Append(DOTween.To(setter => _bar.value = setter, _bar.value, progress, 0.4f));
            
            _barSequence.Play();

            _progressText.text = $"{text} {current}/{total}";
        }
    }
}