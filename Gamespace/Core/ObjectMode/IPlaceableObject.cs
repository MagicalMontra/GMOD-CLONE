using Gamespace.Core.Actions;
using UnityEngine;
using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.ObjectMode.Elevation;
using Gamespace.Core.ObjectMode.PlaceableSurface;
using Gamespace.Core.ObjectMode.Serialization;
using Gamespace.Core.Serialization;
using Zenject;

namespace Gamespace.Core.ObjectMode
{
    public interface IPlaceableObject : IRotatable, IElevatable, ISerializable<ObjectData>
    {
        bool isEnabled { get; }
        string id { get; }
        float lookPercentage { get; set; }
        float distanceFromPlayer { get; set; }
        GameObject gameObject { get; }
        Collider collider { get; }
        Vector3 center { get; }
        Vector3 position { get; }
        Quaternion rotation { get; }
        IMaterialSwapper linkMaterialSwapper { get; }
        IMaterialSwapper placingMaterialSwapper { get; }
        PlaceType placeType { get; }
        IActionBehaviour[] actionBehaviours { get; }
        void SetActive(bool enabled);
        void OnCreateCandidate();
        void SetSpawnCandidatePosition(PlacingData data);
        void OnInitialize();
        void OnDispose();
        void SetParent(IPlaceableSurface surface);

#if UNITY_EDITOR
        void EditorSetup(PlaceType placeType, GameObject model, Transform actionGroup);
#endif
        public class Factory : PlaceholderFactory<Object, IPlaceableObject>
        {
            
        }
    }
}