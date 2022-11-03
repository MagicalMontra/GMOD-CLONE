using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Localization
{
    [CreateAssetMenu(menuName = "Localization/Create Cluster", fileName = "LanguageCluster", order = 0)]
    [Serializable]
    public class LanguageCluster : ScriptableObject
    {
        public string tag;
        public List<LanguageData> list = new List<LanguageData>();

        public LanguageData FindLanguage(string name)
        {
            return list.FindAll(l => l.name.ToLower().Contains(name.ToLower()))[0];
        }
    }
}