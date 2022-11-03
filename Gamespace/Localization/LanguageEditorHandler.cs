#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEditor;
using UnityEngine;

namespace Gamespace.Localization
{
    public class LanguageEditorHandler
    {
        private static bool _isLoggingMissing = true;

        public static LanguageCluster GetCluster(string clusterName)
        {
            var settings = (LanguageSettings)Resources.Load("Localisation Settings");
            var cluster = settings.clusters.Find(c => c.tag == clusterName);
            return cluster;
        }

        public static List<LanguageCluster> GetClusters()
        {
            var settings = (LanguageSettings)Resources.Load("Localisation Settings");
            return settings.clusters;
        }

        public static JSONObject Parse(TextAsset textAsset)
        {
            Debug.Assert(textAsset.text != string.Empty);
            if (string.IsNullOrEmpty(textAsset.text))
                return null;

            var node = JSON.Parse(textAsset.text);

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

                return newObj;
            }

            return null;
        }
        public static void Replace(TextAsset textAsset, JSONObject jsonObject, string key, params string[] args)
        {
            Edit(textAsset, jsonObject, key, args);
        }
        public static void Save(TextAsset textAsset, JSONObject jsonObject)
        {
            File.WriteAllText(AssetDatabase.GetAssetPath(textAsset), jsonObject.ToString());
            EditorUtility.SetDirty(textAsset);
            AssetDatabase.Refresh();
        }
        public static void Add(TextAsset textAsset, JSONObject jsonObject, string idKey, params string[] args)
        {
            if (args.Length <= 1)
            {
                Debug.Log(args[0]);
                jsonObject.Add(idKey, args[0]);
            }
            else
            {
                var options = new JSONObject();
                for (int i = 0; i < args.Length; i++)
                {
                    Debug.Log(args[i]);
                    string word = "";

                    if (i == 0)
                        word = "zero";
                    else if (i == 1)
                        word = "one";
                    else if (i > 1)
                        word = "other";

                    options.Add(word, args[i]);
                }

                jsonObject.Add(idKey, options);
            }

            Save(textAsset, jsonObject);
        }
        public static void Edit(TextAsset textAsset, JSONObject jsonObject, string idKey, params string[] args)
        {
            if (args.Length <= 1)
            {
                jsonObject[idKey].Value = args[0];
            }
            else
            {
                var options = new JSONObject();

                for (int i = 0; i < args.Length; i++)
                {
                    string word = "";

                    if (i == 0)
                        word = "zero";
                    else if (i == 1)
                        word = "one";
                    else if (i > 1)
                        word = "other";

                    options.Add(word, args[i]);
                }

                jsonObject[idKey] = options;
            }

            Save(textAsset, jsonObject);
        }
        public static void Remove(TextAsset textAsset, JSONObject jsonObject, string idKey)
        {
            jsonObject.Remove(idKey);
            Save(textAsset, jsonObject);
        }
        private static string FindSingularOrPlural(JSONObject jsonObject, string key, object[] args)
        {
            JSONObject translationOptions = jsonObject[key].AsObject;
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
        private static int GetCountAmount(object[] args)
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
        private static bool IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            return false;
        }
    }
}
#endif