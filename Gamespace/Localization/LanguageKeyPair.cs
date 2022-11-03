using System;
using System.Collections.Generic;

namespace Gamespace.Localization
{
    [Serializable]
    public class LanguageKeyPair
    {
        public string key;
        public List<string> values = new List<string>();

        public LanguageKeyPair(string key)
        {
            this.key = key;
        }

        public void AddValue(string value)
        {
            var existedIndex = values.FindIndex(v => v == value);
            if (existedIndex == -1)
                values.Add(value);
            else
                values[existedIndex] = value;
        }
    }
}