using System;
using nanoid;
using UnityEngine;

namespace Gamespace.Core.Serialization
{
    public class SerializableReference : MonoBehaviour
    {
        public string id => _id;
        [SerializeField] private string _id;

#if UNITY_EDITOR
        private void Reset()
        {
            if (string.IsNullOrEmpty(_id))
                _id = NanoId.Generate(8);
        }
#endif
    }
}