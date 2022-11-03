using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using Gamespace.Utilis;
using UnityEngine.SceneManagement;
using System.IO;

namespace Gamespace.Load
{
    public class LoadPanelController : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private GameData gameData;   
        
        [SerializeField] private RectTransform _rect;
        [SerializeField] private TextMeshProUGUI _fileName;
        [SerializeField] private Button _loadButton;
        [SerializeField] private Button _deleteButton;
        
        private void Init()
        {
            _loadButton.onClick.AddListener(LoadMenuScene);
            _deleteButton.onClick.AddListener(DeleteLoadFile);
        }
        public void SetFileNameText(string fileName)
        {
            _fileName.text = fileName;
            Init();
        }

        public void SetPanelParent(RectTransform parentTransform)
        {
            _rect.SetParent(parentTransform);
            _rect.localScale = Vector3.one;
            _rect.anchoredPosition = Vector3.zero;
        }
        private void DeleteLoadFile()
        {
            //Delete the file
            
            string path = Application.persistentDataPath;
            path=path+"/Data";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] saveFiles = directoryInfo.GetFiles("*.worklabs");
    
            foreach (FileInfo saveFile in saveFiles)
            {
                string fileName = _fileName.text+".worklabs";
                if(saveFile.Name==fileName)
                {
                    print("ldelete"+path+"/"+fileName);
                    File.Delete(path+"/"+fileName);
                    break;
                }

            }
            Destroy(this.gameObject);
        }

        private void LoadMenuScene()
        {
           // _signalBus.Fire(new SceneLoadRequestSignal("Blueprint"));
           SceneManager.LoadScene(2);
            gameData.mapName = _fileName.text;
        }
        public class Factory : PlaceholderFactory<LoadPanelController>
        {

        }
    }

}
