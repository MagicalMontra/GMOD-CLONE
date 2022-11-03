// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Threading.Tasks;
// using Zenject;
// using TMPro;
// using Gamespace.GameStage;
// using Gamespace..Core.Blueprint;
// public class PauseController : MonoBehaviour
// {
//     public bool isPaused;
//     private bool isSave;
//     public GameObject pausePanel;
//     public GameObject mapSavePanel;
//     public GameObject roomSelectionPanel;
    
//     // Start is called before the first frame update

//     [Inject] private readonly ICurrentGameMode _currentGameMode;
//     void Start()
//     {
//         mapSavePanel.SetActive(false);
//         pausePanel.SetActive(false);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyUp(KeyCode.Escape))
//         {
//             PausePanelHandle();
//         }
    
//     }

//     public void PausePanelHandle()
//     {
//         if (_currentGameMode.GameMode == GameMode.Object)
//         {
//             return;
//         }
//         if (BlueprintController.singleton.GetBlueprintCamera().targetRoom!=null)
//         {
//             return;
//         }
//         if (roomSelectionPanel.activeInHierarchy)
//         {
//             EnablePausePanel(false);
//             return;
//         }
//         if (QuestController.singleton.isActive)
//         {
//             return;
//         }

//         if (!pausePanel.activeInHierarchy)
//         {
//             EnablePausePanel(true);
//         }
//         else
//         {
//             EnablePausePanel(false);
//         }
//     }
//     private void EnablePausePanel(bool isEnable)
//     {
//         isPaused = isEnable;
//         pausePanel.SetActive(isEnable);
//         BlueprintController.singleton.SetPause(isEnable);
//     }
//     public async void ActiveSavePanel()
//     {
//         EnablePausePanel(false);
//         mapSavePanel.SetActive(true);
//         mapSavePanel.GetComponentInChildren<TextMeshProUGUI>().text = "MAP SAVE! \n Save On:" + Application.persistentDataPath;
//         pausePanel.SetActive(false);
//         isSave = true;
//         await Task.Delay(2500);
//         isSave = false;
//         mapSavePanel.SetActive(false);
//     }


// }
