using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionMenu : MonoBehaviour
{
    public void goController()
    {
        SceneManager.LoadScene(4);
    }

    public void goQuiz()
    {
        GameManager.isQuizEnabled = true;
        SceneManager.LoadScene(2);
    }

    public void goDialogue()
    {
        GameManager.isQuizEnabled = false;
        SceneManager.LoadScene(2);
    }
}
