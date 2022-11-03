// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Gamespace..Core.Blueprint;

// using Zenject;


// public class SwitchObjectMode : MonoBehaviour
// {
   
//     public GameObject player;
   
//     public GameObject playerIndicatior;
//     public GameObject blueprintCamera;



//     private void Start()
//     {

//     }
//     void playerFind()
//     {

//     }
//     public void SwitchCamera(bool enabled)
//     {
//         blueprintCamera.SetActive(enabled);
//         EnablePlayerIndicator(enabled);
//     }
//     public void TeleportPlayer(Vector3 teleposPosition)
//     {
//         player.transform.position = teleposPosition;
//         EnablePlayerIndicator(true);
//     }
//     public void EnablePlayerIndicator(bool isEnable)
//     {
//         if (isEnable)
//             playerIndicatior.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);

//         //FIXME: Remove this on refactoring.
//         // if (!isEnable)
//         // {
//         //     playerIndicatior.SetActive(false);
//         // }
//         // else
//         // {
//         //     playerIndicatior.SetActive(true);
//         //     playerIndicatior.transform.position = player.transform.position;
//         // }
//     }

//     GameObject[] FindGameObjectsInLayer(int layer)
//     {
//         var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
//         var goList = new System.Collections.Generic.List<GameObject>();
//         for (int i = 0; i < goArray.Length; i++)
//         {
//             if (goArray[i].layer == layer)
//             {
//                 goList.Add(goArray[i]);
//             }
//         }
//         if (goList.Count == 0)
//         {
//             return null;
//         }
//         return goList.ToArray();
//     }

// }
