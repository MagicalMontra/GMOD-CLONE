using Zenject;
using Gamespace.Core.Blueprint.Room;

namespace Gamespace.Core.Blueprint
{
    public class BlueprintHintWorker : IInitializable, ILateDisposable
    {
        [Inject] private BlueprintHintSetting _blueprintHintSetting;
        public void Initialize()
        {
            _blueprintHintSetting.unselectedHint.SetActive(true);
            _blueprintHintSetting.selectedHint.SetActive(false);
        }

        public void LateDispose()
        {
            
        }
        public void EnableSelectedHint(RoomBase selectedRoom = null)
        {
            if (selectedRoom == null)
            {
                _blueprintHintSetting.unselectedHint.SetActive(true);
                _blueprintHintSetting.selectedHint.SetActive(false);
                return;
            }
            _blueprintHintSetting.unselectedHint.SetActive(false);
            _blueprintHintSetting.selectedHint.SetActive(true);
        }
        public void EnableHintGameObject(bool isEnable)
        {
            if(isEnable==false)
            {
                _blueprintHintSetting.unselectedHint.SetActive(false);
                _blueprintHintSetting.selectedHint.SetActive(false);
                _blueprintHintSetting.menuHint.SetActive(false);
            }
            else
            {
                _blueprintHintSetting.menuHint.SetActive(true);
                _blueprintHintSetting.unselectedHint.SetActive(true);
                _blueprintHintSetting.selectedHint.SetActive(false);
            }
            
        }
    }

}
