using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoints : MonoBehaviour
{
    public GameObject pointPrefab;
    public pointLocation[] nearestPoints;
    // Start is called before the first frame update
    void Awake()
    {
        //GetPointsFunc();
    }

    public void GetPointsFunc()
    {
        StartCoroutine(getJsonOnServer());
    }

    [System.Serializable]
    public class pointLocation
    {
        public float lat;
        public float lng;
    }

    private IEnumerator getJsonOnServer()
    {
        WWW url = new WWW("http://opppo.b99944p9.beget.tech/get_coords");
        yield return url;
        if (url.error != null)
            Debug.Log("Error: " + url.error);
        Debug.Log("Answer: " + url.text);
        string serviceData = "{\"Items\":" + url.text + "}";

        nearestPoints = JsonHelper.FromJson<pointLocation>(serviceData);

        for(int i=0; i< nearestPoints.Length;i++)
            Debug.Log("lat = " + nearestPoints[i].lat + " lng = " + nearestPoints[i].lng);
        placePoint();
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

    public void placePoint()
    {
        for (int i = 0; i < nearestPoints.Length; i++)
        {
            GameObject tmp = Instantiate(pointPrefab) as GameObject;
            tmp.GetComponent<SetGeolocationScript>().SetLoacation(nearestPoints[i].lat, nearestPoints[i].lng, 0);
        }
    }
}
