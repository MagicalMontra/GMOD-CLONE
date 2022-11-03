using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Gamespace.UI
{
    public abstract class UIAnimation : MonoBehaviour, IUIAnimation
    {
        public virtual float Duration => _duration;
        
        [SerializeField] protected Ease _ease = Ease.Linear;
        [Tooltip("Duration of this animation, in composite->sequence mode this mean the delay duration between each sub-sequence")]
        [SerializeField] protected float _duration = 1f;

        [SerializeField] protected int _loop = 1;
        
        public UnityEvent inStart;
        public UnityEvent inComplete;
        public UnityEvent outStart;
        public UnityEvent outComplete;
        
        protected Sequence _sequence;

        [SerializeField] private bool _isOnAwake = true;

        public abstract void In(Sequence sequence);
        public abstract void Out(Sequence sequence);

        public virtual void Reset()
        {
            
        }
        
        protected virtual void OnEnable()
        {
            _isOnAwake = false;
        }
        public virtual async UniTaskVoid On()
        {
            await UniTask.WaitWhile(() => _isOnAwake);

            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _sequence.AppendCallback(() => inStart?.Invoke());
            
            In(_sequence);

            _sequence.AppendInterval(0.25f);
            _sequence.AppendCallback(() => inComplete?.Invoke());


            _sequence.SetLoops(_loop);
            
            _sequence.Play();
            
            await UniTask.Yield();
        }

        public virtual async UniTaskVoid Off()
        {
            await UniTask.WaitWhile(() => _isOnAwake);

            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            
            _sequence.AppendCallback(() => outStart?.Invoke());

            Out(_sequence);

            _sequence.AppendInterval(0.25f);
            _sequence.AppendCallback(() => outComplete?.Invoke());
            
            _sequence.Play();
            
            await UniTask.Yield();
        }
        public virtual void Kill()
        {
            _sequence?.Kill();
        }
        public virtual void OnDestroy()
        {
            _sequence?.Kill();
        }
    }
}