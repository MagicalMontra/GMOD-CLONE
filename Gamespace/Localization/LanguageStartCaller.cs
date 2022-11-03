using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class LanguageStartCaller : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;

        public void LoadStartLanguage()
        {
            _signalBus.Fire(new LanguageRequestSignal());
        }
    }
}