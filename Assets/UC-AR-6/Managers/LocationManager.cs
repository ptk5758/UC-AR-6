using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LocationManager : MonoBehaviour
{
    public UnityEvent<LocationInfo> locationChanged;
    public static bool isLocationServiceRunning = false;

    void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        // Check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            // Debug.LogError("Location services are not enabled by the user.");
            yield break;
        }

        // Start the location service
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds
        if (maxWait <= 0)
        {
            // Debug.LogError("Timed out waiting for location services.");
            yield break;
        }

        // If the connection failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            // Debug.LogError("Unable to determine device location.");
            yield break;
        }
        else
        {
            isLocationServiceRunning = true;
            StartCoroutine(UpdateLocation());
        }
    }

    private IEnumerator UpdateLocation()
    {
        while (isLocationServiceRunning && Input.location.status == LocationServiceStatus.Running)
        {
            LocationInfo currentLocation = Input.location.lastData;

            // Invoke locationChanged event at every interval
            locationChanged?.Invoke(currentLocation);
            // Debug.Log($"Location Invoked: {currentLocation.latitude},{currentLocation.longitude}");

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDisable()
    {
        if (isLocationServiceRunning)
        {
            Input.location.Stop();
            isLocationServiceRunning = false;
        }
    }
}
