using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using System.Text;

using UnityEngine.Networking;

public class DataBase : MonoBehaviour
{
    string path = "https://services8.arcgis.com/8HiM5kvvuLsY4OqQ/ArcGIS/rest/services/Hurricane_Matthew_Storm_Damage/FeatureServer/0/query?where=&objectIds=";
    string opts = "&time=&geometry=&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelIntersects&resultType=none&distance=0.0&units=esriSRUnit_Meter&returnGeodetic=false&outFields=&returnGeometry=true&featureEncoding=esriDefault&multipatchOption=xyFootprint&maxAllowableOffset=&geometryPrecision=&outSR=&datumTransformation=&applyVCSProjection=false&returnIdsOnly=false&returnUniqueIdsOnly=false&returnCountOnly=false&returnExtentOnly=false&returnQueryGeometry=false&returnDistinctValues=false&cacheHint=false&orderByFields=&groupByFieldsForStatistics=&outStatistics=&having=&resultOffset=&resultRecordCount=&returnZ=false&returnM=false&returnExceededLimitFeatures=true&quantizationParameters=&sqlFormat=none&f=pjson&token=";
    string args = "1%2C2%2C3%2C4%2C5%2C6%2C7%2C8%2C9%2C10%2C11%2C12%2C13%2C14%2C15%2C16%2C17%2C18";

    int maxDataPoints = 100;

    public GameObject mapPin;
    // Start is called before the first frame update
    private void Awake()
    {
#if !UNITY_EDITOR
        StartCoroutine(_Awake());
#endif
#if UNITY_EDITOR
        StartCoroutine(GetData(maxDataPoints));
#endif
    }
    IEnumerator _Awake()
    {
        //yield return StartCoroutine(DemoPoints());
        StartCoroutine(GetData(maxDataPoints));
        yield break;
    }

    IEnumerator DemoPoints()
    {
        return null;
    }
    // Update is called once per frame
    IEnumerator GetData(int amount)
    {
        args = "";
        for(int i = 1;i<amount;i++)
        {
            if (i != amount) { args += i + "%2C"; } else {  }
        }
        args += amount;
        Debug.Log(args);

        UnityWebRequest www = new UnityWebRequest(path+args+opts);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            //byte[] results = www.downloadHandler.data;

            string s = www.downloadHandler.text.ToString();

            ParseData(s);
        }
    }

    void ParseData(string results)
    {
        //"attributes/" : {
        string[] stringSeparators = new string[] { "\"attributes\" : {" };
        string[] list = results.ToString().Split(stringSeparators, StringSplitOptions.None);
        foreach (string s in list)
        {
            string[] splt = s.Split(","[0]);

            string x = "";
            string y = "";
            string id = "";

            foreach(string lst in splt)
            {
                string tmp = lst;
                string[] removes = { "{","}","\"",":"," ",",","\n","geometry","[","]"};
                foreach(string rm in removes)
                {
                    if(tmp.Contains(rm))
                    {
                        tmp = tmp.Replace(rm, "");
                    }
                }
                if(tmp.Contains("x"))
                {
                    x = tmp.Replace("x", "");
                }
                if (tmp.Contains("y"))
                {
                    y = tmp.Replace("y", "");
                }
                if(tmp.Contains("OBJECTID"))
                {
                    id = tmp.Replace("OBJECTID", "");
                }
            }

            if (x == "" || y == "" || id == "") { continue; }
            Debug.Log(x + " " + y + " ID:" + id);

            GameObject map_tmp = Instantiate(mapPin, Vector3.zero, Quaternion.identity); ;
            LocativeTarget lt = map_tmp.GetComponent<LocativeTarget>();
            lt.latitude = double.Parse(y);
            lt.longitude = double.Parse(x);
            LocativeLabel ll = map_tmp.GetComponentInChildren<LocativeLabel>();
            ll.SpotTitle = "Location: "+id;
            ll.SpotSubTitle = "lat: "+y+" Lon: "+x;//splt[x];

            Debug.Log(splt);

        }
    }
}
