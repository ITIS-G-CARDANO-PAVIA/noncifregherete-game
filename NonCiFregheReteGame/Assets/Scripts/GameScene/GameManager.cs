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

    [SerializeField]
    public static bool isQuizEnabled = true;

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
