using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

namespace Gamespace.Localization
{
    [Serializable]
    public class LanguageData
    {
        public string name;
        public TextAsset textFile;

        public LanguageData(string name)
        {
            this.name = name;
        }
        public JSONObject Load()
        {
            Debug.AssertFormat(textFile.text != string.Empty, "Language {0} text file load failed.", name);
            if (string.IsNullOrEmpty(textFile.text))
                return null;
            
            var node = JSON.Parse(textFile.text);

            if (node.Tag == JSONNodeType.Object)
            {
                var newObj = new JSONObject();

                foreach (KeyValuePair<string, JSONNode> kvp in (JSONObject) node)
                {
                    if (kvp.Value.ToString().Contains("zero"))
                    {
                        var subObj = new JSONObject();

                        foreach (KeyValuePair<string, JSONNode> skvp in (JSONObject) kvp.Value)
                        {
                            subObj.Add(skvp.Key, skvp.Value);
                        }

                        newObj.Add(kvp.Key, subObj);
                    }
                    else
                        newObj.Add(kvp.Key, kvp.Value);
                }
                return newObj;
            }

            return null;
        }
    }
}
