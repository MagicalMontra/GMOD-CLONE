using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Zenject;
using System.IO;
namespace Gamespace.Load
{
    public class LoadWorker : IInitializable
    {
        [Inject] private LoadPanelController.Factory _loadPanelFactory;
        [Inject] private LoadSetting _loadSetting;

        private List<string> _fileNameList = new List<string>();
        public void Initialize()
        {
           LoadFiles();
        }

        private void LoadFiles()
        {
            string path = Application.persistentDataPath;
            path=path+"/Data";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] saveFiles = directoryInfo.GetFiles("*.worklabs");
    
            foreach (FileInfo saveFile in saveFiles)
            {
                string fileName = saveFile.Name;
                int index = fileName.IndexOf(".");

                if (index >= 0)
                    fileName = fileName.Substring(0, index);

             _fileNameList.Add(fileName);
            }

            GenerateLoadPanel();
        }

        private void GenerateLoadPanel()
        {
            if(_fileNameList.Count==0)
                return;

            for(int i=0;i<_fileNameList.Count;i++)
            {
                LoadPanelController loadPanel = _loadPanelFactory.Create();
                loadPanel.SetPanelParent(_loadSetting.contentTransform);
                loadPanel.SetFileNameText(""+_fileNameList[i]);
            }
        }

    }
}

