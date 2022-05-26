using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesController : MonoBehaviour
{
    public AudioSource win;
    public AudioSource gateAudio;

    //Network bridge = new Network("192.168.0.112");
    //Network gate = new Network("192.168.0.111");
    Network gate = new Network("192.168.0.112");
    Network bridge = new Network("192.168.0.111");
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
            GameManager.dialogueToShow[0] = 2;
            GameManager.dialogueToShow[1] = 3;
            GameManager.quizRange[0] = 0;
            GameManager.quizRange[1] = 11;

            if (GameManager.enabledArgs[1])
            {
                if (GameManager.bypassDialogue)
                {
                    GameManager.isQuizEnabled = true;
                    SceneManager.LoadScene(2);
                }
                else
                {
                    GameManager.isQuizEnabled = false;
                    SceneManager.LoadScene(2);
                }
            }
            else
            {
                GameManager.gateUnlocked = true;
                Debug.Log("gate unlocked");
            }
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
            StartCoroutine(bridge.GetRequest("CW"));
        }
        else if(GameManager.gateUnlocked)
        {

            QuizManager2.obstaclesRequested = 113;
            GameManager.dialogueToShow[0] = 1;
            GameManager.dialogueToShow[1] = 2;
            GameManager.quizRange[0] = 12;
            GameManager.quizRange[1] = 16;

            if (GameManager.enabledArgs[2])
            {
                if (GameManager.bypassDialogue)
                {
                    GameManager.isQuizEnabled = true;
                    SceneManager.LoadScene(2);
                }
                else
                {
                    GameManager.isQuizEnabled = false;
                    SceneManager.LoadScene(2);
                }
            }
            else
            {
                GameManager.bridgeUnlocked = true;
                Debug.Log("bridge unlocked");
            }
        }
    }

    public void closeBridge()
    {
        StartCoroutine(bridge.GetRequest("CCW"));
    }

    public void unlockRobot()
    {
        if (GameManager.robotUnlocked && GameManager.bridgeUnlocked && GameManager.gateUnlocked)
        {
            Debug.Log("Hai vinto!");
            win.Play();
            StartCoroutine(robot.GetRequest("State", "Sbloccato"));
        }
        else if(GameManager.bridgeUnlocked && GameManager.gateUnlocked)
        {

            QuizManager2.obstaclesRequested = 112;
            GameManager.dialogueToShow[0] = 3;
            GameManager.dialogueToShow[1] = 5;
            GameManager.quizRange[0] = 27;
            GameManager.quizRange[1] = 32;

            if (GameManager.enabledArgs[3])
            {
                if (GameManager.bypassDialogue)
                {
                    GameManager.isQuizEnabled = true;
                    SceneManager.LoadScene(2);
                }
                else
                {
                    GameManager.isQuizEnabled = false;
                    SceneManager.LoadScene(2);
                }
            }
            else
            {
                GameManager.robotUnlocked = true;
                Debug.Log("robot unlocked");
            }
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

    public void goToObstaclesPad()
    {
        SceneManager.LoadScene(6);
    }
    //Sblocco robot StartCoroutine(net.GetRequest("State", "Sbloccato"));

}
