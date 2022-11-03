using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomData", menuName = "ScriptableObjects/RoomModelScriptableObject", order = 1)]
public class RoomModelScriptableObject : ScriptableObject
{
    public RoomDetail[] roomDetails;
}
[System.Serializable]
public struct RoomDetail
{
    public GameObject roomPrefab;
    public Sprite roomIcon;
}