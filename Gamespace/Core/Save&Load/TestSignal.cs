using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace  Gamespace.Core.Save
{
    public class TestSignal : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    // Start is called before the first frame update
    void Start()
    {
        _signalBus.Subscribe<PauseRequestSignal>(STES);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            _signalBus.Fire(new PauseRequestSignal(true));
        }
    }

    public void STES(PauseRequestSignal signal)
    {
        print(signal.isPause);
    }
}

}
