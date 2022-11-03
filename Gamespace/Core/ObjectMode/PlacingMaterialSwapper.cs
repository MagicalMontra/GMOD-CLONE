using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.ObjectMode
{
    public class PlacingMaterialSwapper : MonoBehaviour, IMaterialSwapper
    {
        [SerializeField] private Material _activeMaterial;
        [SerializeField] private Material _disableMaterial;
        [SerializeField] private MeshRenderer[] _renderer;

        private bool _isEnabled;
        private bool _isInitialized;
        private List<Material> _originalMaterials = new List<Material>();

#if UNITY_EDITOR
        public void EditorAssignRenderer(MeshRenderer[] renderer)
        {
            _renderer = renderer;
        }
#endif
        public virtual void SetActive(bool enabled)
        {
            if (_isEnabled == enabled && _isInitialized)
                return;

            _isInitialized = true;

            if (_originalMaterials.Count <= 0)
            {
                for (int i = 0; i < _renderer.Length; i++)
                    _originalMaterials.Add(_renderer[i].material);
            }

            Material assigningMaterial;

            assigningMaterial = enabled ? _activeMaterial : _disableMaterial;

            for (int i = 0; i < _renderer.Length; i++)
                _renderer[i].material = assigningMaterial;

            _isEnabled = enabled;
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

            _isEnabled = false;
        }
    }
}