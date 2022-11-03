using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Gamespace.UI
{
    public class GameObjectActivator : UIAnimation
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _active;

        private bool _originState;
        
        public override void In(Sequence sequence)
        {
            _originState = !_active;
            sequence.AppendInterval(_duration);
            sequence.AppendCallback(() => _target.SetActive(_active));
        }

        public override void Out(Sequence sequence)
        {
            sequence.AppendInterval(_duration);
            sequence.AppendCallback(() => _target.SetActive(!_active));
        }
        
        protected async override void OnEnable()
        {
            base.OnEnable();
            _target.SetActive(!_active);
        }
    }
}