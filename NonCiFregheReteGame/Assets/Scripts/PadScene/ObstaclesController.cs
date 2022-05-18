using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesController : MonoBehaviour
{
    
    Network bridge = new Network("192.168.0.111");
    Network gate = new Network("192.168.0.112");
    Network robot = new Network(mainMenuScript.ipAddressRobot);

    public void closeGate()
    {
        StartCoroutine(gate.GetRequest("CW"));
    }

    public void openGate()
    {
        StartCoroutine(gate.GetRequest("CCW"));
    }

    public void unlockRobot()
    {
        StartCoroutine(robot.GetRequest("State", "Sbloccato"));
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
