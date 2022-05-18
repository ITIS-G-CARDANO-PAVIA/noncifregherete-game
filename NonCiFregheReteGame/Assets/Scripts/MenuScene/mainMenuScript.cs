using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    //Indirizzo IP del robot
    public static string ipAddressRobot = "192.168.0.110";

    public void playGame() {
        Network net = new Network("192.168.0.113");
        StartCoroutine(net.GetRequest("ip" + ipAddressRobot));
        SceneManager.LoadScene(1); 
    }

    public void setRobotIp(string s)
    {
        ipAddressRobot = s;
        Debug.Log(ipAddressRobot.ToString());
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("QUIT!");
    }

    public void settingsMenu(){
        SceneManager.LoadScene(3); 
    }

}
