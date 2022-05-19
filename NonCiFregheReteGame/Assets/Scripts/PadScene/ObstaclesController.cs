using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesController : MonoBehaviour
{
    public AudioSource win;
    public AudioSource gateAudio;
    
    Network bridge = new Network("192.168.0.112");
    Network gate = new Network("192.168.0.111");
    Network jammer = new Network("192.168.0.113");
    Network robot = new Network(mainMenuScript.ipAddressRobot);

    public void closeGate()
    {
        StartCoroutine(gate.GetRequest("CCW"));
    }

    public void openGate()
    {
        if (GameManager.gateUnlocked)
        {
            gateAudio.Play();
            StartCoroutine(gate.GetRequest("CW"));
        }
        else
        {
            QuizManager2.obstaclesRequested = 111;
            GameManager.isQuizEnabled = true;
            SceneManager.LoadScene(2);
        }
    }

    public void renableJammer()
    {
        StartCoroutine(jammer.GetRequest("j=enable&"));
    }

    public void openBridge()
    {
        if(GameManager.bridgeUnlocked && GameManager.gateUnlocked)
        {
            gateAudio.Play();
            StartCoroutine(bridge.GetRequest("open"));
        }
        else if(GameManager.gateUnlocked)
        {
            QuizManager2.obstaclesRequested = 113;
            GameManager.isQuizEnabled = true;
            SceneManager.LoadScene(2);
        }
    }

    public void closeBridge()
    {
        StartCoroutine(bridge.GetRequest("close"));
    }

    public void unlockRobot()
    {
        if (GameManager.robotUnlocked && GameManager.bridgeUnlocked && GameManager.gateUnlocked)
        {
            win.Play();
            StartCoroutine(robot.GetRequest("State", "Sbloccato"));
        }
        else if(GameManager.bridgeUnlocked && GameManager.gateUnlocked)
        {
            QuizManager2.obstaclesRequested = 112;
            GameManager.isQuizEnabled = true;
            SceneManager.LoadScene(2);
        }
    }

    public void resetTrack()
    {
        GameManager.gateUnlocked = false;
        GameManager.robotUnlocked = false;
        GameManager.bridgeUnlocked = false;
        closeGate();
        renableJammer();
        closeBridge();
    }

    public void goBack()
    {
        QuizManager2.toReactivate = true;
        SceneManager.LoadScene(0);
    }
    //Sblocco robot StartCoroutine(net.GetRequest("State", "Sbloccato"));

}
