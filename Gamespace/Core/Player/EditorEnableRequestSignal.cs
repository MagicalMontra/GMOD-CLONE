using UnityEngine;

namespace Gamespace.Core.Player
{
    public class EditorEnableRequestSignal
    {
        public string id => _id;
        public Vector3 position => _position;
        private string _id;
        private Vector3 _position;
        public EditorEnableRequestSignal(Vector3 position, string id = "")
        {
            _position = position;
            _id = id;
        }
    }
}