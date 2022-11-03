using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Gamespace.Core.Blueprint
{
    [Serializable]
    public class RoomBuildPanelSetting 
    {
        public GameObject blueprintPanelGameObject;
        public Transform blueprintPanelContent;
        public RoomModelScriptableObject roomInfo;
        public GameObject roomTemplates;
        public GameObject roomButtonPrefab;
    }

}
