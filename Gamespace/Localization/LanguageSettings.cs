using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

namespace Gamespace.Localization
{
    [CreateAssetMenu(fileName = "Localisation Settings", menuName = "Localisation/Create Settings", order = 0)]
    [Serializable]
    public class LanguageSettings : ScriptableObject
    {
        public Language defaultLanguage;
        public List<Language> avaliableLanguages = new List<Language>();
        public List<LanguageCluster> clusters = new List<LanguageCluster>();
    }
}
