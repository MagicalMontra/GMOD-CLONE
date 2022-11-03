#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Gamespace.ObjectPlacer
{
    public class IconGeneratorV2 : MonoBehaviour
    {
        public Transform[] targets;

        public DefaultAsset iconOutputFolder;

        void Start()
        {
            int imageSize = 256;
            string selectFolderPath = AssetDatabase.GetAssetPath(iconOutputFolder);

            if (!Directory.Exists(selectFolderPath))
            {
                Debug.LogError("Could not find the directory " + selectFolderPath + ". Please create it first!");
                return;
            }

            foreach (Transform target in targets)
            {

                RuntimePreviewGenerator.MarkTextureNonReadable = false;
                Texture2D icon = RuntimePreviewGenerator.GenerateModelPreview(target, imageSize, imageSize);
                if (icon == null)
                {
                    throw new System.Exception("icon " + target.name + " = null");
                }

                string iconName = target.gameObject.name;
                GameObject.Find("Canvas").GetComponent<IconGeneratorUIExample>().AddImage(icon, iconName, imageSize); // Used for example, can be removed!
                string filePath = selectFolderPath + "/" + iconName + ".png";
                byte[] bytes = icon.EncodeToPNG();
                File.WriteAllBytes(filePath, bytes);
            }
        }
    }
}
#endif