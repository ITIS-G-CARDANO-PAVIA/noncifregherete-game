using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstaclesPad : MonoBehaviour
{

    Network gate = new Network("192.168.0.112");
    Network bridge = new Network("192.168.0.111");
    Network jammer = new Network("192.168.0.113");
    Network robot = new Network(mainMenuScript.ipAddressRobot);

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
    }

    public void disableJammer()
    {
        StartCoroutine(jammer.GetRequest("j=disable&"));
    }

    public void goToPad()
    {
        SceneManager.LoadScene(4);
    }
}
