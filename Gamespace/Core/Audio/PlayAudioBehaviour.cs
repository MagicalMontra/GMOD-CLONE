using System;
using System.Collections.Generic;
using Gamespace.Core.Actions;
using TMPro;
using UnityEngine;
using Gamespace.Core.GameStage;
using Gamespace.Core.Player;
using Zenject;

namespace Gamespace.Core.Audio
{
    public class PlayAudioBehaviour : VoidActionBehaviour
    {
        [SerializeField] private BoolActionVariable _isLoop;
        [SerializeField] private FloatActionVariable _audioVolume;
        [SerializeField] private StringActionVariable _audioName;
        [SerializeField] private AudioSource _audioSource;
        
        private AudioClip _audioClip;

        public override void OnConstruct()
        {
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
            _signalBus.Subscribe<AudioClipResponseSignal>(OnAudioClipResponse);
        }
        protected override ActionVariable[] Variables()
        {
            return new ActionVariable[]{ _isLoop, _audioVolume, _audioName };
        }
        public override void Perform()
        {
            if(_audioSource == null)
                return;

            _audioSource.loop = _isLoop.value;
            _audioSource.volume = _audioVolume.value;
            _audioSource.clip = _audioClip;

            if(!_audioSource.isPlaying)
                _audioSource.Play();

            Next();
        }
        private void OnAudioClipResponse(AudioClipResponseSignal signal)
        {
            if (signal.data.name != _audioName.value)
                return;
            
            _audioClip = signal.data.clip;
        }
        private void StopAudio()
        {
            if(_audioSource.loop)
                _audioSource.Stop();
        }
        private void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play)
                _signalBus.Fire(new AudioClipRequestSignal(_audioName.value));
            
            if (signal.gameStage == Stage.Object)
                StopAudio();
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
