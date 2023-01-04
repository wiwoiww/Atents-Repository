using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class Test_HTTP_Request : MonoBehaviour
{
    string url = "http://go26652.dothome.co.kr/HTTP_Data/Data.txt";

    private void Start()
    {
        StartCoroutine(GetWebData());
    }

    IEnumerator GetWebData()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log($"Result : {www.downloadHandler.text}");
        }
    }
}
