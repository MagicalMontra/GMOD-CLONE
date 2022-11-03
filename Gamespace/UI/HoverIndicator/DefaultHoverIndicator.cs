using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gamespace.UI.HoverIndicator
{
    public class DefaultHoverIndicator : MonoBehaviour, IHoverIndicator
    {
        [SerializeField] private CanvasGroup _fader;
        [SerializeField] private RectTransform _rect;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Ease _ease = Ease.InOutCirc;


        private Tween _tween;
        public void Disable()
        {
            _tween?.Kill();
            _tween = _fader.DOFade(0, 0.25f).SetEase(_ease).OnComplete(() => gameObject.SetActive(false));
            _tween.Play();
        }
        public void Enable(string indicatorText)
        {
            _text.text = indicatorText;
            _fader.alpha = 0;
            gameObject.SetActive(true);
            _tween?.Kill();
            _tween = _fader.DOFade(1, 0.25f).SetEase(_ease);
            _tween.Play();
        }
        public void UpdatePosition(Vector3 position)
        {
            _rect.position = position;
        }
    }
}