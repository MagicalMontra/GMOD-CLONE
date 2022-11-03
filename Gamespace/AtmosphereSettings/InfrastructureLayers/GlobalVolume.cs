using UnityEngine;
using UnityEngine.Rendering;

namespace Gamespace.AtmosphereSettings
{
    public class GlobalVolume : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private Volume _volume;
#pragma warning restore
        public Volume Volume => _volume;
    }
}