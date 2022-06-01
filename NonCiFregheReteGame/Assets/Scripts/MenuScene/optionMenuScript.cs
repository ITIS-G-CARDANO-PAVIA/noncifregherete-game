using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionMenuScript : MonoBehaviour
{
    public void backIntoMenu(){
        if (GameManager.returnToPad)
        {
            GameManager.returnToPad = false;
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
    public void goToOptions()
    {
        SceneManager.LoadScene(5);
    }
}
