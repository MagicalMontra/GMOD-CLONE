using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.ObjectMode.Selection
{
    [Serializable]
    public class ObjectSelectionSettings
    {
        public List<string> panelButtonIds = new List<string>();
        
        public Camera mainCamera;
        public GameObject indicatorPanel;
    }
}