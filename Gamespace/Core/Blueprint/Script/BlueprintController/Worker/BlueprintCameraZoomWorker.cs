using Zenject;
using UnityEngine;
namespace Gamespace.Core.Blueprint
{
    public class BlueprintCameraZoomWorker : IInitializable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private BlurprintCameraSettings _settings;
        [Inject] private BlueprintCameraZoomInputWorker _zoomInputWorker;

        private bool _isPause;
        public void Initialize()
        {
            _zoomInputWorker.Initialize(ZoomCamera);
            _signalBus.Subscribe<PauseRequestSignal>(OnPauseRequestSignal);
        }
        public void LateDispose()
        {
            _zoomInputWorker.Dispose();
        }
        private void ZoomCamera(float zoomValue)
        {
            if(_isPause)
                return;
                
            var virtualCameraPos = _settings.bluePrintCamera.transform.position;
            virtualCameraPos.y -= zoomValue;

            if (virtualCameraPos.y > _settings.maxZoom)
                virtualCameraPos.y = _settings.maxZoom;

            if (virtualCameraPos.y < _settings.minZoom)
                virtualCameraPos.y = _settings.minZoom;

            _settings.bluePrintCamera.transform.position = virtualCameraPos;
        
        }

        public void OnPauseRequestSignal(PauseRequestSignal signal)
        {
            _isPause = signal.isPause;
        }
        // private void ZoomInCamera()
        // {
        //     if (Input.mouseScrollDelta.y != 0)
        //     {
        //         Vector3 t = transform.position;
        //         t.y -= Input.mouseScrollDelta.y;

        //         if (t.y > _settings.maxZoom)
        //             t.y = _settings.maxZoom;

        //         if (t.y < _settings.minZoom)
        //             t.y = _settings.minZoom;

        //         transform.position = t;
        //     }
        // }
    }

}