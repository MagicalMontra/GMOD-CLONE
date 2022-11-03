using System;
using System.Collections;
using System.Collections.Generic;
using Gamespace.Core.GameStage;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gamespace.Core.Trigger
{
    [RequireComponent(typeof(Collider))]
    public class TriggerArea : MonoBehaviour
    {
        public UnityEvent events;
        
        private bool _isTrigger;
        private bool _isCorrectMode;
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChange);
        }
        private void OnGameStageChange(GameStageSignal signal)
        {
            _isCorrectMode = signal.gameStage == Stage.Play;
        }
        private void OnTriggerStay(Collider other)
        {
            if (!_isCorrectMode)
                return;
            
            if (_isTrigger) 
                return;
            
            _isTrigger = true;
            events.Invoke();
        }
        private void OnTriggerExit(Collider other)
        {
            _isTrigger = false;
        }
    }
}
