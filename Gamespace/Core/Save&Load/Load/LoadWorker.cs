using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Gamespace.Core.Blueprint;
using Gamespace.Core.Blueprint.Room;
using Gamespace.Core.ObjectMode.Serialization;
using Gamespace.Core.Save;
using Zenject;

public class LoadWorker : IInitializable, ILateDisposable
{
    [Inject] private FilePathSetting _filePathSetting;
    [Inject] private LoadSetting _loadSetting;
    [Inject] private RoomBuildPanelWorker _roomBuilPanelWorker;
    private List<GameObject> _roomReferences;
    private string _path;
    public void Initialize()
    {
        if(!_loadSetting.isLoad)
        {            
            if(!_loadSetting.isUsingTemplate)
            {
                //Create startRoom;
                _roomBuilPanelWorker.CreateStartRoom(0);
                return;
            }
            // Create template
            return;
        }

         OnloadMap();     
    }
    public void LateDispose()
    {
        
    }

    private void OnloadMap()
    {
        string root = _loadSetting.rootName;
        _path =  root+_filePathSetting.roomPath;
        OnLoadRooms(_path);
        _path = root+_filePathSetting.objectPath;
        OnLoadObjects(_path);
    }
    private void OnLoadRooms(string roomFilePath)
    {
      
    }

    private void OnLoadObjects(string roomFilePath)
    {
        // var savedObjectData = new List<ISerializable>();
        // var rootObjs = SceneManager.GetActiveScene().GetRootGameObjects();
        //
        // foreach(var root in rootObjs)
        // {
        //     savedObjectData.AddRange(root.GetComponentsInChildren<ISerializable>(true));;
        // }
        //
        // Debug.Log("LoadCount:"+savedObjectData.Count);   
        //
        // for(int i = 0 ; i<savedObjectData.Count ; i++)
        // {
        //     //savedObjectData[i].Deserialize();
        // }

    }

}
