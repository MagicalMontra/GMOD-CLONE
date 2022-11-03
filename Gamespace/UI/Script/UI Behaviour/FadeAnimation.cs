using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class FadeAnimation : UIAnimation
    {
        [SerializeField] private float _start = 0;
        [SerializeField] private float _finish;
        [SerializeField] private CanvasGroup _target;
        [SerializeField] private bool _blockRaycastBefore = true;
        [SerializeField] private bool _isInteractableAfter = true;
        [SerializeField] private bool _blockRaycastAfter = true;
        [SerializeField] private bool _resetOnEnable = true;
        

        public override void In(Sequence sequence)
        {
            sequence.AppendCallback(() =>
            {
                _target.alpha = _start;

                if (Mathf.Approximately(_finish, 1))
                {
                    _target.gameObject.SetActive(true);
                }

                _target.blocksRaycasts = _blockRaycastBefore;
            });
            sequence.Append(_target.DOFade(_finish, _duration).SetEase(_ease));
            sequence.AppendCallback(() =>
            {
                if (Mathf.Approximately(_target.alpha, 1))
                {
                    _target.interactable = _isInteractableAfter;
                    _target.blocksRaycasts = _blockRaycastAfter;
                }
                else if (Mathf.Approximately(_target.alpha, 0))
                {
                    _target.interactable = false;
                    _target.blocksRaycasts = false;
                }
            });
        }
        public override void Out(Sequence sequence)
        {
            sequence.AppendCallback(() => _target.alpha = _finish);
            sequence.Append(_target.DOFade(_start, _duration).SetEase(_ease));
            sequence.AppendCallback(() =>
            {
                if (Mathf.Approximately(_target.alpha, 1))
                {
                    _target.interactable = _isInteractableAfter;
                    _target.blocksRaycasts = _blockRaycastAfter;
                }
                else if (Mathf.Approximately(_target.alpha, 0))
                {
                    if (_target.gameObject.activeInHierarchy)
                        _target.gameObject.SetActive(false);
                    
                    _target.interactable = false;
                    _target.blocksRaycasts = false;
                }
            });
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            
            if (!_resetOnEnable)
                return;
            
            if (_start <= 0)
                _target.alpha = _start;
        }
    }
}