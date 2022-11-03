
using System.Collections.Generic;
using Gamespace.Core.ObjectMode;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public class LinkMaterialSwapper : MonoBehaviour, IMaterialSwapper
    {
        [SerializeField] private MeshRenderer[] _renderers;
        [SerializeField] private Material _linkingMaterial;

        private bool _isEnabled;
        private bool _isInitialized;
        private List<Material> _originalMaterials = new List<Material>();
        
        public void EditorAssignRenderer(MeshRenderer[] renderer)
        {
            _renderers = renderer;
        }
        public void SetActive(bool enabled)
        {
            if (_isEnabled == enabled && _isInitialized)
                return;

            _isInitialized = true;
            
            if (_originalMaterials.Count <= 0)
            {
                for (int i = 0; i < _renderers.Length; i++)
                    _originalMaterials.Add(_renderers[i].material);
            }
            
            for (int i = 0; i < _renderers.Length; i++)
                _renderers[i].material = enabled ? _linkingMaterial : _originalMaterials[i];

            _isEnabled = enabled;
        }
        public void SetOriginalMaterial()
        {
            for (int i = 0; i < _renderers.Length; i++)
                _renderers[i].material = _originalMaterials[i];
            
            _isEnabled = false;
        }
    }
}