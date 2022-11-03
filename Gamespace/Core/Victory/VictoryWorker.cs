using Zenject;
using Gamespace.Core.GameStage;
using Gamespace.Core.Player;
using UnityEngine;
namespace Gamespace.Core.Actions
{
    public class VictoryWorker:IInitializable
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private VictorySetting _victorySetting;

        private bool _isLocked;
        private int _score;

        public void SetUpVictoryPanel(bool isWin)
        {
            string _victoryText = "";
            _victorySetting.victoryCanvas.SetActive(true);
            _victoryText = isWin? "VICTORY":"LOSE";
            _victorySetting.textHeader.text = _victoryText;
            _victorySetting.textScore.text = "Score: "+_score;

            if(!_isLocked)
            {
                _isLocked = true;
               // _signalBus.AbstractFire(new PlayerLockSignal("Victory"));
            }  
        
        }
   
        public void SetScore(int score)
        {
            _score = score;
            // get score from some where
        }
        public void Initialize()
        {
            _victorySetting.victoryCanvas.SetActive(false);
            _victorySetting.closeButton.onClick.AddListener(OnClickCloseButton);
            _signalBus.Subscribe<GameStageSignal>(OnGameStageChanged);
        }
        private void OnClickCloseButton()
        {
            _victorySetting.victoryCanvas.SetActive(false);
            // do something
               if(_isLocked)
               {
                    _isLocked = false;
                    _signalBus.AbstractFire(new PlayerUnlockSignal("Victory"));
               }  
        }
          public void OnGameStageChanged(GameStageSignal signal)
        {
            if (signal.gameStage == Stage.Play)
            {

            }
            
            if (signal.gameStage == Stage.Object)
            {
                if(_isLocked)
                {
                    _isLocked = false;
                    _signalBus.AbstractFire(new PlayerUnlockSignal("Victory"));
                }
                
                _victorySetting.victoryCanvas.SetActive(false);
            }
                
        }
    }

}
