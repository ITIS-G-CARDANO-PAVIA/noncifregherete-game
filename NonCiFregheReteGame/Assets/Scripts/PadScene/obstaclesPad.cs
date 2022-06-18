using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class obstaclesPad : MonoBehaviour
{

    Network gate = new Network("192.168.0.112");
    Network bridge = new Network("192.168.0.111");
    Network jammer = new Network("192.168.0.113");
    Network robot = new Network(mainMenuScript.ipAddressRobot);

    [SerializeField]
    private InputField distanza;

    public void openGate()
    {
        StartCoroutine(gate.GetRequest("CW"));
    }

    public void closeGate()
    {
        StartCoroutine(gate.GetRequest("CCW"));
    }

    public void openBridge()
    {
        StartCoroutine(bridge.GetRequest("CW"));
    }

    public void closeBridge()
    {
        StartCoroutine(bridge.GetRequest("CCW"));
    }

    public void unlockRobotJam()
    {
        StartCoroutine(robot.GetRequest("State", "Sbloccato"));
    }

    public void enableJammer()
    {
        StartCoroutine(jammer.GetRequest("j=enable&"));
        distanza.placeholder.GetComponent<Text>().text = "Distanza";

        int d;
        if (int.TryParse(distanza.text, out d) && distanza.text != "")
        {
            StartCoroutine(jammer.GetRequest("d=" + distanza.text + "&"));
            distanza.text = "";
        }
        else if(!int.TryParse(distanza.text, out d) && distanza.text != "")
        {
            distanza.text = "";
            distanza.placeholder.GetComponent<Text>().text = "Senti";
        }
        
    }

    public void disableJammer()
    {
        StartCoroutine(jammer.GetRequest("j=disable&"));
        distanza.placeholder.GetComponent<Text>().text = "Distanza";

        int d;
        if (int.TryParse(distanza.text, out d) && distanza.text != "")
        {
            StartCoroutine(jammer.GetRequest("d=" + distanza.text + "&"));
            distanza.text = "";
        }
        else if (!int.TryParse(distanza.text, out d) && distanza.text != "")
        {
            distanza.text = "";
            distanza.placeholder.GetComponent<Text>().text = "Senti troia";
        }
        
    }

    public void goToPad()
    {
        SceneManager.LoadScene(4);
    }
}
