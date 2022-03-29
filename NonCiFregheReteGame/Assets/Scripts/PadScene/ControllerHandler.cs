using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class ControllerHandler : MonoBehaviour
{
    [SerializeField]
    private string ipAddress = "http://<ip>/?State=";

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
        }
    }

    public void move()
    {
        string btn = EventSystem.current.name;

        switch (btn)
        {
            case "forwardButton":
                GetRequest(ipAddress + "A");break;
            case "backwardButton":
                GetRequest(ipAddress + "I"); break;
            case "leftButton":
                GetRequest(ipAddress + "S"); break;
            case "rightButton":
                GetRequest(ipAddress + "D"); break;
        }
        Debug.Log(btn);
    }

}
