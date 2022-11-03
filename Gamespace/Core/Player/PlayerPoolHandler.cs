using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class PlayerPoolHandler
    {
        public PlayModePlayer player => _settings.playerPrefab;
        
        [Inject] private PlayerSettings _settings;
        [Inject] private PlayModePlayer.Factory _playerFactory;

        private PlayModePlayer _player;

        public void Spawn(Vector3 spawnPosition)
        {
            //if (ReferenceEquals(_player, null))
            //{
            //    _player = _playerFactory.Create(_settings.playerPrefab, spawnPosition);
            //    return;
            //}

            _settings.playerPrefab.transform.position = spawnPosition;
            _settings.playerPrefab.SetEnable(true);
        }
        public void Despawn()
        {
            _settings.playerPrefab.SetEnable(false);
        }

        //NOTE: This part for multiplayer

        // private List<Player> _pool = new List<Player>();

        // public void Spawn(Vector3 spawnPosition, string id = "")
        // {
        //     var index = _pool.FindIndex(player => player.id == id);
        //
        //     if (index <= -1)
        //     {
        //         _pool.Add(_playerFactory.Create(_settings.playerPrefab, spawnPosition));
        //         return;
        //     }
        //
        //     _pool[index].transform.position = spawnPosition;
        // }
        // public Player Get(string id)
        // {
        //     var index = _pool.FindIndex(player => player.id == id);
        //     return index <= -1 ? null : _pool[index];
        // }
        // public void Destroy(string id)
        // {
        //     var index = _pool.FindIndex(player => player.id == id);
        //
        //     if (index > -1)
        //     {
        //         Object.Destroy(_pool[index].gameObject);
        //         _pool.RemoveAt(index);
        //     }
        // }
        // public void DestroyAll()
        // {
        //     for (int i = 0 - 1; i < _pool.Count; i++)
        //         Object.Destroy(_pool[i].gameObject);
        //     
        //     _pool.Clear();
        // }
    }
}