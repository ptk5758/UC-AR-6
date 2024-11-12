using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaData currentArea = null;

    [SerializeField]
    private List<AreaData> areas;

    public void OnLocationChanged(LocationInfo location)
    {
        Vector2 currentLocation = new Vector2((float)location.latitude, (float)location.longitude);
        AreaData foundArea = null;

        foreach (AreaData area in areas)
        {
            float distance = Vector2.Distance(currentLocation, area.location);
            Debug.Log("거리 차이 : " + distance);
            if (distance <= area.range)
            {
                foundArea = area;
                break;
            }
        }
        currentArea = foundArea;
    }
}
