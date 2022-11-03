using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Serialization
{
    [CreateAssetMenu(menuName = "Serializable/Create SerializableDatabase", fileName = "SerializableDatabase", order = 0)]
    public class SerializableDatabase : ScriptableObject
    {
        [SerializeField] private SerializableReference _fallback;
        [SerializeField] private List<SerializableReference> _references = new List<SerializableReference>();

        public GameObject GetPrefab(string uniqueId)
        {
            var index = _references.FindIndex(reference => reference.id == uniqueId);

            if (index < 0)
                return _fallback.gameObject;

            return _references[index].gameObject;
        }
    }
}