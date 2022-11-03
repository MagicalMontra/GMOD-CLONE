using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Gamespace.Core.Actions;
public class VictoryMonoTest : MonoBehaviour
{
    [Inject] VictoryWorker _victoryAction;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
        {
            _victoryAction.SetUpVictoryPanel(true);
        }
    }
}
