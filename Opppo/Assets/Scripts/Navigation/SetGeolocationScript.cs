using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGeolocationScript : MonoBehaviour
{
    public float lat;
    public float lon;
    public float orientation;

    private float initX;
    private float initZ;

    private bool gpsFix;
    private float fixLat;
    private float fixLon;
    private MapScript _gameHelper;
    void Awake()
    {
        _gameHelper = GameObject.FindObjectOfType<MapScript>();
        gpsFix = _gameHelper.gpsFix;
    }

    IEnumerator Start()
    {
        while (!gpsFix)
        {
            gpsFix = _gameHelper.gpsFix;
            yield return null;
        }
        initX = _gameHelper.IniRef.x;
        initZ = _gameHelper.IniRef.z;

        yield return new WaitForSeconds(1);
        GeoLocation();
    }

    void GeoLocation()
    {
        Vector3 pos = transform.position;
        pos.x = (float)(((lon * 20037508.34) / 18000) - initX);
        pos.z = (float)(((Mathf.Log(Mathf.Tan((90 + lat) * Mathf.PI / 360))
            / (Mathf.PI / 180)) * 1113.19490777778) - initZ);
        pos.y = 0;
        transform.position = pos;
        Vector3 eAngles = transform.eulerAngles;
        eAngles.y = orientation;
        transform.eulerAngles = eAngles;
    }

    public void SetLoacation(float latitude, float longitude, float newOrientation)
    {
        lat = latitude;
        lon = longitude;
        orientation = newOrientation;
        GeoLocation();
    }
}
