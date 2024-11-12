using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaData", menuName = "Scriptable Objects/AreaData")]
public class AreaData : ScriptableObject
{
    public string areaName;
    public Vector2 Location;
    public float range;
}
