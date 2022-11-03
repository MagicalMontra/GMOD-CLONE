using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Gamespace.Core.ObjectMode.Serialization;
using Gamespace.Core.Blueprint;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Gamespace.Core.GameStage;
using Cysharp.Threading.Tasks;
using System.Linq;

namespace Gamespace.Core.Save
{
    public class SaveWorker : IInitializable, ILateDisposable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private FilePathSetting _filePathSetting;
        [Inject] private SaveInputWorker _saveInputWorker;
        [Inject] private SaveSetting _saveSetting;

        private bool _isPause;
        private bool _isOnBlueprintMode;
        public void Initialize()
        {
            _saveInputWorker.Initialize(OnToggleSavePanel);
            _saveSetting.closeButton.onClick.AddListener(OnToggleSavePanel);
            _saveSetting.saveButton.onClick.AddListener(() => OnClickSaveButton().Forget());
            _saveSetting.savePanel.SetActive(false);
            _saveSetting.saveNoticePanel.SetActive(false);
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
        }

        public void LateDispose()
        {
            _saveInputWorker.Dispose();
        }

        public  async UniTaskVoid OnClickSaveButton()
        {
            string rootName=_saveSetting.saveNameInputField.text;
            string filePath = rootName+_filePathSetting.roomPath;
            SaveRoom(filePath);
            filePath = rootName+_filePathSetting.objectPath;

            // var savedObjectData = new List<ISerializable>();
            // var rootObjs = SceneManager.GetActiveScene().GetRootGameObjects();
            //
            // foreach(var root in rootObjs)
            // {
            //     savedObjectData.AddRange(root.GetComponentsInChildren<ISerializable>(true));;
            // }
            //
            // for(int i = 0 ; i<savedObjectData.Count ; i++)
            // {
            //     savedObjectData[i].Serialize();
            // }
            //
            // await UniTask.WaitUntil(() => savedObjectData.All(data => data.isStored));
            // _saveSetting.savePanel.SetActive(false);
            // Debug.Log(savedObjectData.Count);
            // _signalBus.Fire(new SaveRequestSignal(""));
            //  _serializationWorker.SaveFunction(filePath);
            TriggerSavedNoticePanel();
            await UniTask.Yield();
        }


        private void SaveRoom(string path)
        {
            List<GameObject> roomRef = new List<GameObject>();

            if(roomRef.Count<=0)
                return;

            string filePath = path;
        }
        private async void TriggerSavedNoticePanel()
        {
            _signalBus.Fire(new PauseRequestSignal(true));
            _saveSetting.saveNoticePanel.SetActive(true);
            await Task.Delay(1000);
            _saveSetting.saveNoticePanel.SetActive(false);
            _signalBus.Fire(new PauseRequestSignal(false));
        }
        public void OnToggleSavePanel()
        {
            if(!_isOnBlueprintMode)
                return;

            if(_saveSetting.savePanel.activeInHierarchy)
            {
                _saveSetting.savePanel.SetActive(false);
            }
            else
            {
                _saveSetting.savePanel.SetActive(true);
            }
           
            _signalBus.Fire(new PauseRequestSignal(_saveSetting.savePanel.activeInHierarchy));
        } 
        private void OnGameStageChanged(GameStageSignal signal)
        {            
            if (signal.gameStage == Stage.Play || signal.gameStage == Stage.Object)
            {
                _saveSetting.savePanel.SetActive(false);
                _isOnBlueprintMode = false;
                return;
            }
            _isOnBlueprintMode = true;
        
        }
    }
    
  
        

}
