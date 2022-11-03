using UnityEngine;
using System.Threading.Tasks;
using Zenject;

namespace Gamespace.Core.Blueprint
{
   
    public class BlueprintCameraMoveWorker : IInitializable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private BlurprintCameraSettings _settings;
        [Inject] private BlueprintCameraMoveInputWorker _moveInputWorker;
        private bool _isPause;

        public void Initialize()
        {
            _moveInputWorker.Initialize(Move);
            _signalBus.Subscribe<PauseRequestSignal>(OnPauseRequestSignal);
        }
        public void LateDispose()
        {
            _moveInputWorker.Dispose();
        }
        private void Move(float x, float y)
        {
            if(_isPause)
                return;

            var vector = Vector3.zero;
            vector.x += x;
            vector.z += y;
            _settings.bluePrintCamera.transform.position += vector;
        }
        public void OnPauseRequestSignal(PauseRequestSignal signal)
        {
            _isPause = signal.isPause;
        }
    }
}