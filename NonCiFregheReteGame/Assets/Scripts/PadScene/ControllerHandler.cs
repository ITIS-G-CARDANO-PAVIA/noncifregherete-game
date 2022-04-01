using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class ControllerHandler : MonoBehaviour
{
    private string ipAddress = "http://192.168.4.1/?State=";

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public void move()
    {
        string btn = EventSystem.current.name;
        switch (btn)
        {
            case "forwardButton":
                StartCoroutine(GetRequest("http://192.168.4.1/?State=A"));
                break;
            case "backwardButton":
                StartCoroutine(GetRequest("http://192.168.4.1/?State=I"));
                break;
            case "leftButton":
                StartCoroutine(GetRequest("http://192.168.4.1/?State=I"));
                break;
            case "rightButton":
                StartCoroutine(GetRequest("http://192.168.4.1/?State=I"));
                break;
        }
        Thread.Sleep(500); //Working time
        StartCoroutine(GetRequest("http://192.168.4.1/?State=Ferma"));
    }

}
