using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI
{
    public class ScrollingBackground : MonoBehaviour
    {
        public float bgSpeed;
        public Image bgRend;

        void Update()
        {
            bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0);
        }
    }
}