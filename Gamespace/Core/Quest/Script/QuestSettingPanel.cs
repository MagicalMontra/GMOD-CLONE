using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Gamespace.Core.Quest
{
    public class QuestSettingPanel : MonoBehaviour
{
    private QuestController questController;
    public Button button;
    private string panelQuestId;
    public TMP_InputField questId;
    public TMP_InputField completeValue;
    public TMP_InputField description;
    public TMP_InputField score;
    public QuestInfo questInfo;
    private string description_;
    private int completeValue_;
    private int score_;
    private void Start()
    {
        button.onClick.AddListener(RemovePanel);
    }
    private void OnEnable()
    {
        if (!string.IsNullOrEmpty(panelQuestId))
        {
            questId.interactable = false;
        }
    }
    private void OnDisable()
    {
        if (string.IsNullOrEmpty(panelQuestId))
        {
            return;
        }

        if (panelQuestId == null)
        {
            return;
        }

        for (int i = 0; i < questController.questInfos.Count; i++)
        {
            if (questController.questInfos[i].questId == panelQuestId)
            {
                questController.questInfos[i].description = description_;
                questController.questInfos[i].valueToComplete = completeValue_;
                questController.questInfos[i].score = score_;
            }
        }
    }
    public void SetUpController(QuestController controller)
    {
        questController = controller;
    }
    public void SetUpInputField(QuestInfo questInfo_)
    {
        questId.text = questInfo_.questId;
        completeValue.text = ""+ questInfo_.valueToComplete;
        description.text = questInfo_.description;
        score.text = ""+questInfo_.score;
    }
    public void OnSaveQuestId()
    {
        questInfo.questId = questId.text;
        panelQuestId = questId.text;
    }
    public void OnSaveCompleteValue()
    {
        int value = int.Parse(completeValue.text);

        completeValue_ = value;
    }
    public void OnSaveDescription()
    {
        description_ = description.text; 
    }
    public void OnSaveScore()
    {
        print(score.text);
        int value = int.Parse(score.text);
        score_ = value;
      
    }
    void RemovePanel()
    {
        questController.OnRemoveQuest(questId.text);
        print(questId.text);
        Destroy(this.gameObject);
    }
    void ChangeScore(string questId_)
    {
        
    }
}

}
