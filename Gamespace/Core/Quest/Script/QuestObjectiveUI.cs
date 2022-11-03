using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Gamespace.Core.Quest
{
    public class QuestObjectiveUI : MonoBehaviour
{
    public GameObject questObjectiveObj;
    public GameObject objectiveHeader;
    public bool isEditor;
    public Transform questContent;
    private QuestController questController;
    private List<QuestObjectivePanel> panels = new List<QuestObjectivePanel>();
    public void Setup(QuestController questController_)
    {
        questController = questController_;
    }

    private void Update()
    {
        if (!isEditor)
        {
            if (panels.Count > 0)
            {
                objectiveHeader.SetActive(true);
            }
            else
            {
                objectiveHeader.SetActive(false);
            }
        }
    }
    public void CreateObjectiveOnStart()
    {
        if (questController.questInfos.Count == 0)
        {
            return;
        }
        if (questController.questOnStart == 0)
        {
            return;
        }
        if (questController.questOnStart > questController.questInfos.Count)
        {
            questController.questOnStart = questController.questInfos.Count;
        }
        for (int i = 0; i < questController.questOnStart; i++)
        {
            if (questController.questInfos[i] == null)
            {
                return;
            }

            CreateObjective(questController.questInfos[i]);
        }
    }
    public void CreateObjective(QuestInfo questInfo_)
    {
        GameObject o = Instantiate(questObjectiveObj);
        o.transform.SetParent(questContent);
        RectTransform rect = o.GetComponent<RectTransform>();
        rect.localScale = Vector3.one;
        rect.anchoredPosition = Vector3.zero;

  
        questInfo_.isShowed = true;
        QuestObjectivePanel questObjectivePanel = o.GetComponent<QuestObjectivePanel>();
        if(questInfo_.questId==null || string.IsNullOrEmpty(questInfo_.questId))
        {
            questInfo_.questId = "A1";
        }
        questObjectivePanel.questId = questInfo_.questId;
        panels.Add(questObjectivePanel);
        QuestUpdate(questObjectivePanel.questId);

    }
    public void QuestUpdate(string questId_)
    {
        QuestInfo info = null;
        QuestObjectivePanel panel = null;
        if (panels.Count == 0)
        {
            return;
        }
        if (questController.questInfos.Count==0)
        {
            return;
        }

        for (int i = 0; i < panels.Count; i++)
        {
            if (panels[i].questId == questId_)
            {
                panel = panels[i];
            }
        }
        for (int i = 0; i < questController.questInfos.Count; i++)
        {
           if( questController.questInfos[i].questId == questId_)
            {
                info = questController.questInfos[i];
            }
        }

        string t = "";
        t += info.description;
        if (info.valueToComplete > 1)
        {
            t += " "+info.questValue+"/" + info.valueToComplete;
        }
        if (info.isComplete)
        {
            panel.toggle.isOn = true;
        }
        panel.description.text = t;
    }
    public void OnRemoveQuestUI(string questId_)
    {
        QuestObjectivePanel panel = null;
        for (int i = 0; i < panels.Count; i++)
        {
            if (panels[i].questId == questId_)
            {
                panel = panels[i];
            }
        }
        if (panel == null)
        {
            return;
        }
        panels.Remove(panel);
        Destroy(panel.gameObject);
    }
}

}
