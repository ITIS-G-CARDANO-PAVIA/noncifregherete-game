using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesController : MonoBehaviour
{
    Network net = new Network("192.168.0.112");
    private string ipadd = mainMenuScript.ipAddress;

    public void f90()
    {
        StartCoroutine(net.GetRequest("P90&"));
    }

    public void f180()
    {
        StartCoroutine(net.GetRequest("P180&"));
    }

    public void sendIp()
    {
        StartCoroutine(net.GetRequest("ip"+ipadd));
    }

    public void goBack()
    {
        QuizManager2.toReactivate = true;
        SceneManager.LoadScene(2);
    }

    public void unlockTheTrack()
    {

    }

    //Sblocco robot StartCoroutine(net.GetRequest("State", "Sbloccato"));

}
