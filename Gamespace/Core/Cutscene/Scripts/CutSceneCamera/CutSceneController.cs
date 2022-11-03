using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using TMPro;
using com.ootii.Actors;
using com.ootii.Cameras;
using Gamespace.Core.Player;
using Gamespace.Core.Actions;
using Gamespace.Core.GameStage;
using Zenject;

public class CutSceneController : MonoBehaviour
{
    [SerializeField] private GameObject mainVirtureCamera;

    private GameObject _actionCutSceneCamera;

    [Inject]
    private SignalBus _signalBus;

    [Header("Player Controller")]
    [SerializeField]
    CutSceneBlackImage cutSceneBlackImage;
    [SerializeField] 
    BasicController basicController;
    [SerializeField] 
    CameraController cameraController;

    private float waitingTimeCounter;
    private float waitingTime=0.25f;
    private float _timer;
    private bool _isRun;
    private bool _isFreezeCamera;

    [Header("Look At target")]
    public Transform target;
    private bool isModeFindTarget;
    private RaycastHit hit;
  //  private CutSceneProperties cutSceneProps;
    private void Awake()
    {
        _signalBus.Subscribe<GameStageSignal>(GetMode);
    }
    void GetMode(GameStageSignal signal)
    {
        if (signal.gameStage == Stage.BluePrint || signal.gameStage == Stage.Object)
        {
            DisableCamera(0f);
          //  _signalBus.Fire(new PlayerUnlockSignal("","CutScene"));
         //   _signalBus.Fire(new PlayerUnlockSignal("", "ActionProperty"));
            cutSceneBlackImage.ActiveBlackImages(false);
            return;
        }
        cutSceneBlackImage.ActiveBlackImages(true);
    }
    private void Update()
    {
        CutSceneTimer();
       // OnFindTargetMode();
    }
    private void OnFindTargetMode()
    {
        if (isModeFindTarget)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3))
            {
                if (hit.collider)
                {
                    target = hit.collider.transform;

                    if (Input.GetMouseButtonUp(0))
                    {
                     //   cutSceneProps.SetTargetName(target);
                     //   OnTriggerFindTagetMode();
                    }
                }

            }
            else
            {
                target = null;

                if (Input.GetMouseButtonUp(0))
                {
                    //cutSceneProps.SetTargetName(target);
                   // OnTriggerFindTagetMode();
                }
            }
        }
    }
    private void CutSceneTimer()
    {
        if (_isFreezeCamera)
        {
            _timer = -1f;
            _isRun = false;
            return;
        }

        DelayCameraWithTimer();

    }
    private void DelayCameraWithTimer()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            waitingTimeCounter = waitingTime;
            _isRun = true;
        }

        if (_isRun)
        {
            if (_timer <= 0)
            {
                if (waitingTimeCounter == waitingTime)
                {
                    ActiveCamera(true);
                }

                if (waitingTimeCounter <= 0)
                {
                    cutSceneBlackImage.FadeBlackImage(true);
                    _isRun = false;
                }

                waitingTimeCounter -= Time.deltaTime;
            }
        }
    }
    public bool GetFreezeCamera()
    {
        return _isFreezeCamera;
    }
    public async void DisableCamera(float delay)
    {
        await Task.Delay(Mathf.CeilToInt(delay * 1000));
        _timer = -1f;
        _isRun = false;
        _isFreezeCamera = false;

        cutSceneBlackImage.FadeBlackImage(true);
        ActiveCamera(true);
    }
    public void ActiveCamera(bool enabled)
    {
        basicController.enabled = enabled;
        cameraController.enabled = enabled;

        if (mainVirtureCamera)
        {
            mainVirtureCamera.SetActive(enabled);
        }

        if (_actionCutSceneCamera)
        {
            _actionCutSceneCamera.SetActive(!enabled);
        }

        if (enabled)
        {
          //  _signalBus.AbstractFire(new PlayerLockSignal("Cutscene"));
            return;
        }
        
        _signalBus.AbstractFire(new PlayerUnlockSignal("Cutscene"));
    }
  
    public void SetCutScene(GameObject cutSceneCamera_, float time_, bool _isFreeze)
    {
        _isFreezeCamera = _isFreeze;
        _actionCutSceneCamera = cutSceneCamera_;
        _timer = time_;
        
        ActiveCamera(false);
        cutSceneBlackImage.FadeBlackImage(false);
    }

    // public async void  OnTriggerFindTagetMode(CutSceneProperties cutSceneProperties=null)
    // {
    //     _signalBus.AbstractFire(new PlayerLockSignal("", "ActionProperty"));
    //     await Task.Delay(Mathf.CeilToInt(500));
    //     isModeFindTarget = !isModeFindTarget;
    //     lookTargetNameText.gameObject.SetActive(isModeFindTarget);
    //     cutSceneProps = cutSceneProperties;
    // }

}
