using UnityEngine;
using System.Collections.Generic;

namespace Gamespace.Core.Blueprint
{
    public class RoomMaterialSwapper : MonoBehaviour, IMaterialSwapper<int>
    {
        [SerializeField] private Material[] _materials;
        [SerializeField] private MeshRenderer[] _renderer;
        
        private int _index;
        private bool _isInitialized;
        private List<Material> _originalMaterials = new List<Material>();
        
#if UNITY_EDITOR
        public void EditorAssignRenderer(MeshRenderer[] renderer)
        {
            _renderer = renderer;
        }
#endif
        public virtual void SetActive(int index)
        {
            if (_index == index && _isInitialized)
                return;

            _isInitialized = true;

            if (_originalMaterials.Count <= 0)
            {
                for (int i = 0; i < _renderer.Length; i++)
                    _originalMaterials.Add(_renderer[i].material);
            }

            Material assigningMaterial;

            assigningMaterial = _materials[index];

            for (int i = 0; i < _renderer.Length; i++)
                _renderer[i].material = assigningMaterial;

            _index = index;
        }
        public virtual void SetOriginalMaterial()
        {
            if (_originalMaterials.Count <= 0)
            {
                for (int i = 0; i < _renderer.Length; i++)
                    _originalMaterials.Add(_renderer[i].material);
            }
            
            for (int i = 0; i < _renderer.Length; i++)
                _renderer[i].material = _originalMaterials[i];

            _index = -1;
        }
    }
}
