using System;
using System.Collections.Generic;

namespace Gamespace.Localization
{
    [Serializable]
    public class LocalisedString
    {
        public string clusterTag;
        public string key;
        public List<string> args = new List<string>();
    }
}