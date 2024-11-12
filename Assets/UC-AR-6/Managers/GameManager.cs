using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public static GameObject actived = null;
    public void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARPlane> args)
    {
        if (actived != null)
            return;
        if (AreaManager.currentArea == null)
            return;
        AreaData area = AreaManager.currentArea;
        foreach (ARPlane plane in args.added) {
            actived = Instantiate(area.prefab);
            actived.transform.position = plane.center;
        }
    }

}
