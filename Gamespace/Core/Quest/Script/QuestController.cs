using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Gamespace.Core.GameStage;
using  System.Threading.Tasks;
using TMPro;

namespace Gamespace.Core.Quest
{
    public class QuestController : MonoBehaviour
{
   
    [Inject] private SignalBus _signalBus;
    private QuestObjectiveUI questObjective;
    public bool isActive;
    private bool isEditor;
    public int questOnStart = 0;
    public List<QuestInfo> questInfos = new List<QuestInfo>();
    [Header("MainQuestUI")]
    public GameObject mainQuestSettingCanvas;
    public GameObject mainQuestObjectiveCanvas;
    public TMP_InputField questOnStartInput;
    [Header("QuestPanelUI")]
    public GameObject hintText;
    public Button addQuestButton;
    public RectTransform content;
    public GameObject questSettingPanel;
    [Header("Debug")]
    public string forceQuestID="A1";

    private void Start()
    {
        addQuestButton.onClick.AddListener(OnAddQuest);
        _signalBus.Subscribe<GameStageSignal>(GetMode);
        questObjective = GetComponentInChildren<QuestObjectiveUI>();
        questObjective.Setup(this);
     //   LoadQuest();
    }
    private void Update()
    {
        if (isEditor)
        {
            if (Input.GetKeyUp(KeyCode.F1))
            {
                mainQuestSettingCanvas.SetActive(true);
                hintText.SetActive(false);
                isActive = true;
            }


            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (mainQuestSettingCanvas.activeInHierarchy)
                {
                    mainQuestSettingCanvas.SetActive(false);
                    hintText.SetActive(false);
                    isActive = false;
                }
            }


        }
        else
        {

        }
        //Debug;
        //DebugMode(); 
    }
    private void DebugMode()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            OnInteractWithQuest("" + forceQuestID);
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            OnResetQuest();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            mainQuestObjectiveCanvas.SetActive(true);
            questObjective.CreateObjectiveOnStart();
        }
    }
    void GetMode(GameStageSignal signal)
    {
        if( signal.gameStage == Stage.BluePrint)
        {
            mainQuestObjectiveCanvas.SetActive(false);
            hintText.SetActive(true);
            isEditor = true;
            questObjective.isEditor = isEditor;
            OnResetQuest();
            return;
        }
        if(signal.gameStage == Stage.Object)
        {
            isEditor = false;
            questObjective.isEditor = isEditor;
            mainQuestSettingCanvas.SetActive(false);
            mainQuestObjectiveCanvas.SetActive(false);
            hintText.SetActive(false);
            OnResetQuest();
            return;
        }
        questObjective.CreateObjectiveOnStart();
        isEditor = false;
        questObjective.isEditor = isEditor;
        mainQuestObjectiveCanvas.SetActive(true);
        mainQuestSettingCanvas.SetActive(false);
        hintText.SetActive(false);
    }
    public void OnAddQuest()
    {
        QuestSettingPanel QuestsettingInfo = CreateQuestSettingPanel(); 
        questInfos.Add(QuestsettingInfo.questInfo);

    }
    private QuestSettingPanel CreateQuestSettingPanel()
    {
        GameObject ob = Instantiate(questSettingPanel);
        ob.transform.SetParent(content);
        RectTransform r = ob.GetComponent<RectTransform>();
        r.localScale = Vector3.one;
        r.anchoredPosition = Vector3.zero;
        QuestSettingPanel qSetting = ob.GetComponent<QuestSettingPanel>();
        qSetting.SetUpController(this);
        return qSetting;
      
    }
    public void OnRemoveQuest(string questId_)
    {
        QuestInfo questInfo = null;
        if (questInfos.Count ==0)
        {
            return;
        }
        for (int i = 0; i < questInfos.Count; i++)
        {
           if( questInfos[i].questId == questId_)
            questInfo = questInfos[i];
        }
        questInfos.Remove(questInfo);
    }
    public void OnInteractWithQuest(string questId_)
    {
        for (int i = 0; i < questInfos.Count; i++)
        {
            if (questInfos[i].questId == questId_)
            {
                if (questInfos[i].isComplete)
                {
                    return;
                }

                if (!questInfos[i].isShowed)
                {
                    return;
                }

                if (questInfos[i].valueToComplete == 0 || questInfos[i].valueToComplete == 1)
                {
                    questInfos[i].isComplete = true;
                }

                if (questInfos[i].isComplete == false)
                {
                    questInfos[i].questValue++;

                    if (questInfos[i].questValue >= questInfos[i].valueToComplete)
                    {
                        questInfos[i].questValue = questInfos[i].valueToComplete;
                        questInfos[i].isComplete = true;
                    }
                }

                questObjective.QuestUpdate(questInfos[i].questId);

                if (questInfos[i].isComplete)
                {
                    OnQuestComplete(questInfos[i]);
                }

            }
        }
    }
    public void LoadQuest()
    {
        //LOAD
        //On start scene show up quest if exsit
        if (questInfos.Count == 0)
        {
            return;
        }
        for (int i = 0; i < questInfos.Count; i++)
        {
            QuestSettingPanel QuestsettingInfo = CreateQuestSettingPanel();
            QuestsettingInfo.SetUpInputField(questInfos[i]);
        }

        questOnStartInput.text =""+ questOnStart;
    }
    private void OnResetQuest()
    {
        //Exit gameplay mode
        for (int i = 0; i < questInfos.Count; i++)
        {
            questInfos[i].questValue = 0;
            questInfos[i].isComplete = false;
            questInfos[i].isShowed  = false;
            questObjective.OnRemoveQuestUI(questInfos[i].questId);
        }
    }
    public void SetUpQuestOnStart()
    {
        // How manyQuest will show on start with UI inputfield
        questOnStart = int.Parse( questOnStartInput.text);

    }
    public async void ForceShowQuest(string questId)
    {
        await Task.Delay(Mathf.CeilToInt(1500));
        QuestInfo questInfo_ = null;

        for (int i = 0; i < questInfos.Count; i++)
        {
          if(questInfos[i].questId == questId)
            {
                questInfo_ = questInfos[i];
            }
        }

        if(questInfo_.isComplete || questInfo_.isShowed)
        {
            return;
        }

        questObjective.CreateObjective(questInfo_);

    }
    public  bool CheckQuest(string questId)
    {
       // Check if quest is completed
        QuestInfo questInfo_ = null;

        for (int i = 0; i < questInfos.Count; i++)
        {
            if (questInfos[i].questId == questId)
            {
                questInfo_ = questInfos[i];
            }
        }

        if (questInfo_.isComplete)
        {
            return true;
        }

        return false;

    }
    private async void OnQuestComplete(QuestInfo questInfo)
    {
         await Task.Delay(Mathf.CeilToInt(1600));
        Debug.Log(questInfo.questId+"Quest complete");
       
        questObjective.OnRemoveQuestUI(questInfo.questId);

        //for (int i = 0; i < questInfos.Count; i++)
        //{
        //    if (questInfos[i].isShowed == false)
        //    {
        //        questObjective.CreateObjective(questInfos[i]);
        //        return;
        //    }
        //}
    }
}

[System.Serializable]
public class QuestInfo
{
    public string questId;
    public string description;
    public int questValue;
    public int valueToComplete;
    public int score;
    public bool isComplete;
    public bool isShowed;
}
}
