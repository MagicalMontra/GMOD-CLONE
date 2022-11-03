using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class EditorPlayerPoolHandler
    {
        public EditorPlayer player => _settings.playerPrefab;
        
        [Inject] private EditorPlayerSettings _settings;
        [Inject] private EditorPlayer.Factory _playerFactory;

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
    }
}