using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gamespace.Core.Actions;
using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ParticleObject
{
    public class StopParticleBehaviour : VoidActionBehaviour
    {
        public BoolActionVariable waitForFinish;

        [SerializeField] private ParticleSystem _targetParticle;
        
        public override void OnConstruct()
        {
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
        }
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ waitForFinish };
        }
        public override void Perform()
        {
            if(_targetParticle==null)
                return;
            
            if (waitForFinish.value)
            {
                WaitAndNext().Forget();
                return;
            }

            if (_targetParticle.isPlaying)
            {
                _targetParticle.Simulate(0, true, true);
            }

            Next();
        }
        private async UniTaskVoid WaitAndNext()
        {
            await UniTask.WaitWhile(() => _targetParticle.isPlaying);
            _targetParticle.Simulate(0, true, true);
            Next();
            await UniTask.Yield();
        }
        private void StopParticle()
        {
            if (_targetParticle is null)
                return;
        }
        private void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage != Stage.Play)
                StopParticle();
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