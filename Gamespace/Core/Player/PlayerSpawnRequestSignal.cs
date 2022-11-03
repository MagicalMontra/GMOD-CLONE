using UnityEngine;
namespace Gamespace.Core.Player
{
    public class PlayerSpawnRequestSignal
    {
        public string id => _id;
        public Vector3 position => _position;
        private string _id;
        private Vector3 _position;

        public PlayerSpawnRequestSignal(Vector3 position, string id = "")
        {
            _position = position;
            _id = id;
        }
    }

    public class PlayerDespawnRequestSignal
    {
        
    }

    public class PlayerInitializedSignal
    {
        public PlayModePlayer player => _player;
        private PlayModePlayer _player;

        public PlayerInitializedSignal(PlayModePlayer player)
        {
            _player = player;
        }
    }
}