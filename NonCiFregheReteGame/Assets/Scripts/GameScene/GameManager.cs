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

    public static bool isQuizEnabled = true;
    public static bool gateUnlocked = false;
    public static bool bridgeUnlocked = false;
    public static bool robotUnlocked = false;

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
