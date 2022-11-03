using System;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.GameStage
{
    public class GameStageChangeMono : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private Stage stageToChangeTo;

        public void ChangeStage()
        {
            _signalBus.Fire(stageToChangeTo);
        }
    }
}