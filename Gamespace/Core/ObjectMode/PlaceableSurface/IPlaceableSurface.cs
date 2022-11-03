using Gamespace.Core.ObjectMode.PlaceableSurface.Serialization;
using Gamespace.Core.Serialization;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.PlaceableSurface
{
    public interface IPlaceableSurface : ISerializable<SurfaceData>
    {
        string id { get; }
        float distanceFromPlayer { get; set; }
        float lookPercentage { get; set; }
        float lookThreshold { get; }
        PlaceType placeType { get; }
        Collider collider { get; }
        Transform transform { get; }
        void OnInitialize();
        void OnDispose();
    }
}