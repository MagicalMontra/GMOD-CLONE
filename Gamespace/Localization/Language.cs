using System;
using UnityEngine;

namespace Gamespace.Localization
{
    [Serializable]
    public class Language
    {
        public string name;
        public TextAsset wordWrapDatabase;

        public Language(string name)
        {
            this.name = name;
        }
    }
}