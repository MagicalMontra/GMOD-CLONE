using UnityEngine;

namespace Gamespace.Core
{
    public interface IMaterialSwapper
    {
#if UNITY_EDITOR
        void EditorAssignRenderer(MeshRenderer[] renderer);
#endif
        void SetActive(bool enabled);
        void SetOriginalMaterial();
    }
    
    public interface IMaterialSwapper<TContract>
    {
#if UNITY_EDITOR
        void EditorAssignRenderer(MeshRenderer[] renderer);
#endif
        void SetActive(TContract contract);
        void SetOriginalMaterial();
    }
}