using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Gamespace.SceneLoader;

public class SceneController : MonoBehaviour
{
     [Inject] private SignalBus _signalBus;
     
   // [SerializeField] private SceneReference sceneToLoad;
    public void NormalLoadSceneWithIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void SceneLoader()
    {
        //LoadSceneWithPlugin(sceneToLoad);
    }
    private void LoadSceneWithPlugin(string sceneName = null)
    {
        if (sceneName != null)
        {
            //_signalBus.Fire(new SceneLoadRequestSignal(sceneName));
        }
    }
    
}
