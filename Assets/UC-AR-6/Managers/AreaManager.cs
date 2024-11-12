using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaData currentArea = null;

    [SerializeField]
    private List<AreaData> areas;

    [SerializeField]
    private TMP_Text debug_distanceText;

    public void OnLocationChanged(LocationInfo location)
    {
        Vector2 currentLocation = new Vector2((float)location.latitude, (float)location.longitude);
        AreaData foundArea = null;

        foreach (AreaData area in areas)
        {
            float distance = Vector2.Distance(currentLocation, area.location) * 1000;
            // Debug.Log("거리 차이 : " + distance);
            debug_distanceText.text = "distance : " + distance;
            if (distance <= area.range)
            {
                foundArea = area;
                break;
            }
        }
        currentArea = foundArea;
    }
}
