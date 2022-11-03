using System.Collections.Generic;
using Zenject;

namespace Gamespace.Core.ObjectMode.PlaceableSurface
{
    public class PlaceableSurfaceWorker
    {
        [Inject] private SignalBus _signalBus;
        private List<IPlaceableSurface> _surfaces = new List<IPlaceableSurface>();

        public void OnSurfaceInitialized(PlaceableSurfaceInitializeSignal signal)
        {
            signal.surface.OnInitialize();
            HandleCrossId(signal.surface);
            _surfaces.Add(signal.surface);
        }
        public void OnSurfaceDisposed(PlaceableSurfaceDisposeRequestSignal signal)
        {
            var index = -1;
            
            if (string.IsNullOrEmpty(signal.id))
                index = _surfaces.FindIndex(surface => surface.id == signal.id);

            if (index > -1)
            {
                if (_surfaces[index] != null)
                    _surfaces[index].OnDispose();
                
                _surfaces.RemoveAt(index);
            }
            else
            {
                for (int i = 0; i < _surfaces.Count; i++)
                {
                    if (_surfaces[i] is null)
                        continue;
                        
                    _surfaces[i].OnDispose();
                }
                        
                _surfaces.Clear();
            }
            
            _signalBus.Fire(new PlaceableSurfaceDisposeResponseSignal());
        }
        public void OnSurfaceRequested(IPlaceableSurfaceRequestSignal signal)
        {
            _signalBus.Fire(new PlaceableSurfaceResponseSignal(signal.requestId, _surfaces));
        }
        private void HandleCrossId(IPlaceableSurface surface)
        {
            if (_surfaces.Exists(s => s.id == surface.id))
            {
                surface.OnInitialize();
                
                if (_surfaces.Exists(s => s.id == surface.id))
                    HandleCrossId(surface);
            }
        }
    }
}