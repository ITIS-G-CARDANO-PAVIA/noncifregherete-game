using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{

    public GameObject PauseScreen;
    bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
    }

    public void pauseGame(){
        gamePaused = true;
        PauseScreen.SetActive(true);
    }

    public void resumeGame(){
        gamePaused = false;
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePaused == true){
            Time.timeScale = 0;
            PauseScreen.SetActive(true);
        }else{
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
        }
        
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
