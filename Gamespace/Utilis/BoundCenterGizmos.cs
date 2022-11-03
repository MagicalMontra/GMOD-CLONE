using UnityEngine;

namespace Gamespace.Utilis
{
    public class BoundCenterGizmos : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        
        private void OnDrawGizmos()
        {
            if (_collider == null)
                return;
            
            Gizmos.DrawSphere(_collider.bounds.center, 0.5f);
        }
    }
}