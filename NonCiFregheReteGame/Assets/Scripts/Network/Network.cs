using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class Network {
    public string ipAddress { get; set; }

    public Network(string ipAddress)
    {
        this.ipAddress = ipAddress;
    }

    public IEnumerator GetRequest(string param)
    {
        string uri = "http://" + ipAddress + "/?" + param;
        using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        yield return webRequest.SendWebRequest();
    }
    public IEnumerator GetRequest(string key, string value)
    {
        yield return GetRequest(key + "=" + value);
    }
}
