using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Blueprint.Room
{
    public class RoomButtonConsumer : MonoBehaviour
    {
        private int _roomIndex;
        [Inject] private RoomBuildPanelWorker _roomBuildPanelWorker;
        public void SetUp(int indx, Sprite icon,Transform parentTransform)
        {
            _roomIndex = indx;
            this.transform.SetParent(parentTransform);
            GetComponent<Image>().sprite = icon;
            GetComponent<RectTransform>().localScale = Vector3.one;
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
           _roomBuildPanelWorker.CreateRoomFromPrefab(_roomIndex);
        }
        public class Factory : PlaceholderFactory<RoomButtonConsumer>
        {
            
        }
    }
}
