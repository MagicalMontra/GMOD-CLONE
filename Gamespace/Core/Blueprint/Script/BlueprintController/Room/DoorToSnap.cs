using UnityEngine;
using Gamespace.Core.Blueprint.Room;

namespace Gamespace.Core.Blueprint.Room
{
    public class DoorToSnap : MonoBehaviour
    {
        [SerializeField] private RoomBase roomBase;

        // Start is called before the first frame update
        void Awake()
        {
            roomBase = GetComponentInParent<RoomBase>();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<DoorToSnap>())
            {
                if (roomBase == null)
                    return;

                if (!roomBase.isSelected)
                    return;

                if (roomBase.isOverlap)
                {
                    roomBase.isSnapping = false;
                    return;
                }

                if (roomBase.isSnapping)
                    return;

                roomBase.isSnapping = true;
                Vector3 v = other.transform.position - this.transform.position;
                transform.SetParent(null);
                transform.position = other.transform.position;

                roomBase.transform.position += v;

                // roomBase.OnDeselected();
                transform.SetParent(roomBase.transform);

            }
        }
        public void SnapDoor()
        {
            var otherPosition = new Vector3(1.0f, 2.0f, 3.0f);
            // Will correctly change the transform
            // parentTransform.position = parentTransform.position - otherPosition;
        }
    }
}