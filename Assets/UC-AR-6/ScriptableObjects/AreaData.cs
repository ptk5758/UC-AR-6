using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaData", menuName = "Scriptable Objects/AreaData")]
public class AreaData : ScriptableObject
{
    public string areaName;
    public Vector2 location;
    public float range;
    public GameObject prefab;
}
