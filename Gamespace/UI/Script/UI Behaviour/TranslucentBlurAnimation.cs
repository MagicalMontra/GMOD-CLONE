using DG.Tweening;
using LeTai.Asset.TranslucentImage;
using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class TranslucentBlurAnimation : UIAnimation
    {
        [SerializeField] private ScalableBlurConfig _source;
        [SerializeField] private float _start;
        [SerializeField] private float _end;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public override void In(Sequence sequence)
        {
            _source.Strength = _start;
            sequence.AppendCallback(() => _signalBus?.Fire(new BlurBeginRequestSignal(_source.name, _end, _duration, _ease)));
        }
        public override void Out(Sequence sequence)
        {
            sequence.AppendCallback(() => _signalBus?.Fire(new BlurCancelRequestSignal(_source.name, _start, _duration, _ease)));
        }

        public override void Reset()
        {

        }
    }
}