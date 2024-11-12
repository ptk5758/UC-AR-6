using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARPlane> args)
    {
        if (AreaManager.currentArea == null)
            return;
        AreaData area = AreaManager.currentArea;
        foreach (ARPlane plane in args.added) {
            GameObject spawned = Instantiate(area.prefab);
            spawned.transform.position = plane.center;
        }
    }

}
