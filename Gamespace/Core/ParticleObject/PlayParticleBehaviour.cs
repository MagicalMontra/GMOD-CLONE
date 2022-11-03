using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gamespace.Core.Actions;
using UnityEngine;
using Gamespace.Core.GameStage;
using Zenject;

namespace Gamespace.Core.ParticleObject
{
    public class PlayParticleBehaviour : VoidActionBehaviour
    {
        [SerializeField] private BoolActionVariable _isLoop;
        [SerializeField] private BoolActionVariable _waitForFinish;

        [SerializeField] private ParticleSystem _targetParticle;
        private ParticleSystem.MainModule _targetMainParticle;

        public override void OnConstruct()
        {
            _targetMainParticle = _targetParticle.main;
        }
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[] { _isLoop, _waitForFinish };
        }
        public override void Perform()
        {
            if(_targetParticle==null)
                return;
            
            if (!_targetParticle.gameObject.activeInHierarchy)
                _targetParticle.gameObject.SetActive(true);

            _targetMainParticle.loop = _isLoop.value;
            
            if(!_targetParticle.isPlaying)
                _targetParticle.Play();

            if (_waitForFinish.value)
            {
                WaitAndNext().Forget();
                return;
            }

            Next();
        }
        private async UniTaskVoid WaitAndNext()
        {
            await UniTask.WaitWhile(() => _targetParticle.isPlaying);
            Next();
            await UniTask.Yield();
        }
        public override Type[] GetAcceptingTypes()
        {
            var types = new List<Type>
            {
                typeof(IntActionBehaviour),
                typeof(VoidActionBehaviour),
                typeof(FloatActionBehaviour),
                typeof(StringActionBehaviour)
            };
            return types.ToArray();
        }
    }
}