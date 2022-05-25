using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class configMenu : MonoBehaviour
{
    public void edFakeNews()
    {
        GameManager.enabledArgs[0] = false;
    }
    public void edGaming()
    {
        GameManager.enabledArgs[1] = false;
    }
    public void edOdio()
    {
        GameManager.enabledArgs[2] = false;
    }
    public void edResto()
    {
        GameManager.enabledArgs[3] = false;
        Debug.Log("disabilitato");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
