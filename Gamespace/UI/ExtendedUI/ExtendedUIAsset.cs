using UnityEngine;
using System;

namespace Gamespace.UI
{
    [Serializable]
    public class ExtendedUIAsset
    {
        public GameObject onNormal;
        public GameObject onPressBg;
        public GameObject onHighlightBg; //NOTE: Hover
        public GameObject onDisableBg;
    }
}
