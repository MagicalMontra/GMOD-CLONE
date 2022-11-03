using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
namespace Gamespace.Core.Actions
{
    [Serializable]
    public class VictorySetting 
    {
        public GameObject victoryCanvas;
        public TextMeshProUGUI textHeader;
        public TextMeshProUGUI textScore;
        public Button closeButton;
    }

}
