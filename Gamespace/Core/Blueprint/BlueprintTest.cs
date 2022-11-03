using System.Collections;
using System.Collections.Generic;
using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;
public class BlueprintTest : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;

    [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
        }


void GetStage(GetStageSignal signal)
{
     print("stage signal" + signal);
}
    void OnGameStageChanged(Stage stage)
    {
            print("TTTT" + stage);
    }

       private void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play)
            {

            }
            
                print("TTTT" + signal.gameStage);

        }
}
