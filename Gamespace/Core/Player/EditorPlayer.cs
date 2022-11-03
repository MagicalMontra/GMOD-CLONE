using Cinemachine;
using com.ootii.Actors;
using com.ootii.Game;
using com.ootii.Input;
using nanoid;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Player
{
    public class EditorPlayer : MonoBehaviour
    {
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


        [SerializeField] private Transform _camera;
        [SerializeField] private GameObject _inputSourceObject;
        [SerializeField] private Transform _playerObject;
        [SerializeField] private BasicController _controller;

        private IInputSource _inputSource;

        public void SetEnable(bool enabled)
        {
            gameObject.SetActive(enabled);
        }

        public class Factory : PlaceholderFactory<Object, Vector3, EditorPlayer>{}
    }

    public class EditorPlayerFactory : IFactory<Object, Vector3, EditorPlayer>
    {
        private DiContainer _container;
        
        public EditorPlayerFactory(DiContainer container)
        {
            _container = container;
        }
        public EditorPlayer Create(Object prefab, Vector3 position)
        {
            var instance = _container.InstantiatePrefabForComponent<EditorPlayer>(prefab);
            instance.playerPosition = position;
            return instance;
        }
    }
}