using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

namespace Gamespace.Core.Save
{
    [Serializable]
    public class SaveSetting
    {
        public GameObject savePanel;
        public GameObject saveNoticePanel;
        public TMP_InputField saveNameInputField;
        public Button saveButton;
        public Button closeButton;
    }

}
