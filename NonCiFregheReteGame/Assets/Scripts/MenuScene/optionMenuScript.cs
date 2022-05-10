using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionMenuScript : MonoBehaviour
{
    public void backIntoMenu(){
        SceneManager.LoadScene(0);
    }
}
