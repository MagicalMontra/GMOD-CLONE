using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using Zenject;

namespace Gamespace.Localization
{
    public class LanguageDataLoader
    {
        private JSONObject _data;
        private bool _isLoggingMissing;
        
        public string GetValue(LanguageData data, string key, params object[] args)
        {
            Initialize(data);
            
            if (ReferenceEquals(_data, null))
                return key;

            string value = key;
            if (_data[key] != null)
            {
                // if this key is a direct string
                if (_data[key].Count == 0)
                {
                    value = _data[key];
                }
                else
                {
                    value = FindSingularOrPlural(key, args);
                }
                // check if we have embeddable data
                if (args.Length > 0)
                {
                    value = string.Format(value, args);
                }
            }
            else if (_isLoggingMissing)
            {
                Debug.Log("Missing translation for:" + key);
            }
             
            return value;
        }
        private void Initialize(LanguageData data)
        {
            if (data.textFile != null)
            {
                var jsonAsset = data.textFile;

                Debug.AssertFormat(jsonAsset.text != string.Empty, "Language {0} text file load failed.", data.name);
                if (string.IsNullOrEmpty(jsonAsset.text))
                    return;

                var node = JSON.Parse(jsonAsset.text);

                if (node.Tag == JSONNodeType.Object)
                {
                    var newObj = new JSONObject();

                    foreach (KeyValuePair<string, JSONNode> kvp in (JSONObject)node)
                    {
                        if (kvp.Value.ToString().Contains("zero"))
                        {
                            var subObj = new JSONObject();

                            foreach (KeyValuePair<string, JSONNode> skvp in (JSONObject)kvp.Value)
                            {
                                subObj.Add(skvp.Key, skvp.Value);
                            }

                            newObj.Add(kvp.Key, subObj);
                        }
                        else
                            newObj.Add(kvp.Key, kvp.Value);
                    }

                    _data = newObj;
                }
            }
        }
        private string FindSingularOrPlural(string key, object[] args)
        {
            JSONObject translationOptions = _data[key].AsObject;
            string translation = key;
            string singPlurKey;
            // find format to try to use
            switch (GetCountAmount(args))
            {
                case 0:
                    singPlurKey = "zero";
                    break;
                case 1:
                    singPlurKey = "one";
                    break;
                default:
                    singPlurKey = "other";
                    break;
            }
            // try to use this plural/singular key
            if (translationOptions[singPlurKey] != null)
            {
                translation = translationOptions[singPlurKey];
            }
            else if (_isLoggingMissing)
            {
                Debug.Log("Missing singPlurKey:" + singPlurKey + " for:" + key);
            }
            return translation;
        }
        private int GetCountAmount(object[] args)
        {
            int argOne = 0;
            // if arguments passed, try to parse first one to use as count
            if (args.Length > 0 && IsNumeric(args[0]))
            {
                argOne = Math.Abs(Convert.ToInt32(args[0]));
                if (argOne == 1 && Math.Abs(Convert.ToDouble(args[0])) != 1)
                {
                    // check if arg actually equals one
                    argOne = 2;
                }
                else if (argOne == 0 && Math.Abs(Convert.ToDouble(args[0])) != 0)
                {
                    // check if arg actually equals one
                    argOne = 2;
                }
            }
            return argOne;
        }
        private bool IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            return false;
        }
    }
}