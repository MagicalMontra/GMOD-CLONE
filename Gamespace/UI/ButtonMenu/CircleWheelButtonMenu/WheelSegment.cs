using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    public class WheelSegment : MonoBehaviour
    {
        private void Reset(float zRotation, Transform parent)
        {
            transform.SetParent(parent);
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(0, 0, zRotation);
        }
        public class Pool : MonoMemoryPool<float, Transform, WheelSegment>
        {
            protected override void Reinitialize(float zRotation, Transform parent, WheelSegment segment)
            {
                segment.Reset(zRotation, parent);
            }
        }
    }
}