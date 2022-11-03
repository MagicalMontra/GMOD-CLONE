using Cinemachine;
using com.ootii.Actors;
using com.ootii.Game;
using com.ootii.Input;
using SickscoreGames.HUDNavigationSystem;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class PlayModePlayer : MonoBehaviour
    {
        public string id;
        public bool SetEnabled
        {
            set => _controller.MovementEnabled = value;
        }
        public Vector3 playerPosition
        {
            set => _playerObject.transform.position = value;
        }
        
        public Vector3 position => _camera.transform.position;

        public IInputSource inputSource
        {
            get
            {
                _inputSource ??= _inputSourceObject.GetComponent<IInputSource>();
                return _inputSource;
            }
        }

        public GameCore gameCore;
        public CinemachineVirtualCameraBase camera;


        [SerializeField] private HUDNavigationSystem _hudNavigationSystem;
        [SerializeField] private Transform _camera;
        [SerializeField] private GameObject _inputSourceObject;
        [SerializeField] private BasicController _controller;
        [SerializeField] private Transform _playerObject;

        private IInputSource _inputSource;

        public void SetEnable(bool enabled)
        {
            gameObject.SetActive(enabled);
            _hudNavigationSystem.EnableSystem(enabled);
        }
        
        public class Factory : PlaceholderFactory<Object, Vector3, PlayModePlayer>{}
    }
}