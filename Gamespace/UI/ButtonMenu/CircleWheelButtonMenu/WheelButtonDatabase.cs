using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.UI
{
    [CreateAssetMenu(menuName = "Gamespace/WheelMenu/Create WheelButtonDatabase", fileName = "WheelButtonDatabase", order = 0)]
    public class WheelButtonDatabase : ScriptableObject
    {
        public int count => _datas.Count;
        [SerializeField] private List<WheelButtonData> _datas = new List<WheelButtonData>();

        public WheelButtonData GetData(string id)
        {
            WheelButtonData data;
            data = _datas.Find(buttonData => buttonData.id == id);
            return data;
        }
        public WheelButtonData GetData(int index)
        {
            if (index < 0)
                index = 0;

            if (index > _datas.Count - 1)
                index = _datas.Count - 1;

            return _datas[index];
        }
        public void Add(WheelButtonData data)
        {
            _datas.Add(data);
        }
        public void Remove(int index)
        {
            _datas.RemoveAt(index);
        }
    }
}