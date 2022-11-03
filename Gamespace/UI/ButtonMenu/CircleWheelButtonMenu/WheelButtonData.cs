using System;
using UnityEngine;

namespace Gamespace.UI
{
    [Serializable]
    public class WheelButtonData
    {
        public string id;
        public string desc;
        public bool unlock = true;
        public bool useCustomColor;
        public Color color;
        public Sprite icon;

        public void Clone(WheelButtonData data)
        {
            id = data.id;
            desc = data.desc;
            unlock = data.unlock;
            useCustomColor = data.useCustomColor;
            color = data.color;
            icon = data.icon;
        }
    }
}