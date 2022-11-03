using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gamespace.Core.GameStage;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.Music
{
    public class BackgroundWorker : ITickable,IInitializable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private BackGroundMusicSetting _backGroundMusicSetting;
        private bool _isRun;

        public void Initialize()
        {
          TriggerBGM();
          _signalBus.Subscribe<GameStageSignal>(OnGameStageChange);
        }

        public void Tick()
        {
            if(_isRun)
            {
                if (!_backGroundMusicSetting.audioSource.isPlaying)
                {
                    TriggerNewEditorMusic();
                }
            }
        }

        private async void TriggerBGM()
        {
            await Task.Delay(1000);
            _isRun = true;
        }
        private void TriggerNewEditorMusic()
        {
            int rd = Random.Range(0,_backGroundMusicSetting.clips.Length);
            _backGroundMusicSetting.audioSource.clip = _backGroundMusicSetting.clips[rd];
            _backGroundMusicSetting.audioSource.Play();
        }
        private void OnGameStageChange(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Object||signal.gameStage == Stage.BluePrint)
            {
                if(!_isRun)
                {
                    TriggerBGM();
                    TriggerNewEditorMusic();
                }
                return;
            }
            _isRun=false;
            _backGroundMusicSetting.audioSource.Stop();
        }
    }
}

