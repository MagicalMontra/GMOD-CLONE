using UnityEngine;

namespace Gamespace.Core.Player
{
    public class EditorPlayerLookAtRequestSignal : IPlayerLookAtRequestSignal
    {
        public Vector3 position => _position;
        private Vector3 _position;
        public EditorPlayerLookAtRequestSignal(Transform lookAtTarget)
        {
            _position = lookAtTarget.position;
        }
        public EditorPlayerLookAtRequestSignal(Vector3 position)
        {
            _position = position;
        }
    }

    public interface IPlayerLookAtRequestSignal
    {
        Vector3 position { get; }
    }
}