using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    //Finale 110, 111, 112
    public static string ipAddress = "0.0.0.0";

    public void playGame() {
        Network net = new Network(ipAddress);

        SceneManager.LoadScene(1); 
    }

    public void setRobotIp(string s)
    {
        ipAddress = s;
        Debug.Log(ipAddress.ToString());
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("QUIT!");
    }

    public void settingsMenu(){
        SceneManager.LoadScene(3); 
    }

}
