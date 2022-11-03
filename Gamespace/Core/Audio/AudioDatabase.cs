using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gamespace.Core.Audio
{
    [CreateAssetMenu(fileName = "AudioDatabase", menuName = "Gamespace/Action/Audio/AudioDatabase", order = 1)]
    public class AudioDatabase : ScriptableObject
    {
        [SerializeField] private AudioClip _fallbackSound;
        [SerializeField] private List<AudioData> _datas = new List<AudioData>();

        public string[] Search(string keyword)
        {
            var names = new List<string>();
            _datas.FindAll(data => data.name.ToLower().Contains(keyword)).ForEach(data => names.Add(data.name));
            
            if (names.Count < 0)
                names.Add(_fallbackSound.name);
            
            return names.ToArray();
        }
        public AudioData Get(string name)
        {
            var index = _datas.FindIndex(data => data.name == name);
            AudioData returnData = new AudioData();
            returnData.name = name;
            returnData.clip = _fallbackSound;

            if (index > -1)
                returnData = _datas[index];

            return returnData;
        }
        public AudioData Get(int index)
        {
            if (index < 0)
                index = 0;

            if (index >= _datas.Count)
                index = _datas.Count - 1;

            return _datas[index];
        }
    }

}
