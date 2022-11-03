using System;
using Gamespace.UI;
using UnityEngine;

public class OptimizedModernUIEditorController : MonoBehaviour
{
    [Serializable]
    public class PanelPair
    {
        public GameObject panel;
        public ExtendedButton button;
    }

    public PanelPair[] controlPairs;

    private void Awake()
    {
        for (int i = 0; i < controlPairs.Length; i++)
            controlPairs[i].panel.SetActive(false);
        
        controlPairs[0].panel.SetActive(true);
        
        for (int i = 0; i < controlPairs.Length; i++)
        {
            var controller = controlPairs[i];
            controller.button.onClick.AddListener(() =>
            {
                for (int j = 0; j < controlPairs.Length; j++)
                    controlPairs[j].panel.SetActive(false);
                
                controller.panel.SetActive(true);
            });
        }
    }
}