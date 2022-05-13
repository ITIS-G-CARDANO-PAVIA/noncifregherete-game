using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    //Finale 110, 111, 112

    [SerializeField]
    private InputField inp;
    public static string ipAddress;

    public void playGame() { 
        ipAddress = inp.ToString();
        Network net = new Network(ipAddress);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    
    public void quitGame(){
        Application.Quit();
        Debug.Log("QUIT!");
    }

    public void settingsMenu(){
        SceneManager.LoadScene(3); 
    }

}
