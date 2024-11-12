using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaData currentArea = null;

    [SerializeField]
    private List<AreaData> areas;

    [SerializeField]
    private TMP_Text areaNameText;

    public void OnLocationChanged(LocationInfo location)
    {
        Vector2 currentLocation = new Vector2((float)location.latitude, (float)location.longitude);
        AreaData foundArea = null;

        foreach (AreaData area in areas)
        {
            float distance = Vector2.Distance(currentLocation, area.location) * 1000;
            // Debug.Log("거리 차이 : " + distance);
            // debug_distanceText.text = "distance : " + distance;
            if (distance <= area.range)
            {
                areaNameText.text = "위치 : " + area.areaName;
                Debug.Log("끼얏호우 : " + area.areaName);
                foundArea = area;
                break;
            }
        }
        currentArea = foundArea;
    }
}
