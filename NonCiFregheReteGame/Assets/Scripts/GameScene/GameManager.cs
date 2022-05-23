using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject dialogueUI;

    [SerializeField]
    private GameObject quizUI;

    
    //Quiz flag
    public static bool isQuizEnabled = true;

    //Bypass dialogue
    public static bool bypassDialogue = false;

    //Obstacles flags
    public static bool gateUnlocked = false;
    public static bool bridgeUnlocked = false;
    public static bool robotUnlocked = false;

    //Dialogue to show index and quiz range
    public static int[] dialogueToShow = {0, 1};
    public static int[] quizRange = {21, 30};

    void checkQuiz()
    {

        if (!isQuizEnabled)
        {
            quizUI.SetActive(false);
            dialogueUI.SetActive(true);
        }
        else
        {
            quizUI.SetActive(true);
            dialogueUI.SetActive(false);
        }
    }

    void Start()
    {
        checkQuiz();
    }

    // Update is called once per frame
    void Update()
    {
        checkQuiz();
    }
}
