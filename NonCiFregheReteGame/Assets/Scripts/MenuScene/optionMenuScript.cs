using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionMenuScript : MonoBehaviour
{
    public void backIntoMenu(){
        SceneManager.LoadScene(0);
    }
    public void goToOptions()
    {
        SceneManager.LoadScene(5);
    }
}
