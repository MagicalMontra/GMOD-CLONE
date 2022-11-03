using DG.Tweening;

namespace Gamespace.UI
{
    public class BlurCancelRequestSignal
    {
        public string name => _name;
        public float target => _target;
        public float duration => _duration;
        public Ease ease => _ease;
        private string _name;
        private float _target;
        private float _duration;
        private Ease _ease;
        
        public BlurCancelRequestSignal(string name, float target, float duration, Ease ease = Ease.Unset)
        {
            _name = name;
            _target = target;
            _duration = duration;
            _ease = ease;
        }
    }
}