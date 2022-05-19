using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager2 : MonoBehaviour
{
    [SerializeField]
    private int minForPad = 2;

    public static bool toReactivate = false;
    public TextAsset quizJSON;
    public TextMeshProUGUI question;
    public Button[] answerButtons = new Button[3];
    public static int currentQuizIdx = 0;
    private int correctResponse = 0;
    private JSONManager.Quiz[] quiz;
    public AudioSource wrongAudio;
    public AudioSource correctAudio;
    public Animator robotAnimator;

    private static List<int> alreadyAsked = new List<int>();
    /*
        111 = gate
        112 = jammer
        113 = bridge
     */
    public static int obstaclesRequested = 000;

    void Start()
    {
        JSONManager json = new JSONManager();
        quiz = json.readQuizz(quizJSON).quiz;
        correctResponse = 0;
        showQuiz();
    }

    int indexToAsk()
    {

        int rdm;
        do
        {
            rdm = Random.Range(0, quiz.Length);
        } while (alreadyAsked.Contains(rdm));
        alreadyAsked.Add(rdm);
        return rdm;
    }

    void showQuiz()
    {
        robotAnimator.Play("ATTENDERE");
        JSONManager.Quiz currentQuiz = quiz[indexToAsk()];
        question.text = currentQuiz.toAsk;
        List<string> answers = new List<string>();
        answers.AddRange(currentQuiz.falseResponse);
        answers.Add(currentQuiz.trueResponse);
        foreach(Button button in answerButtons)
        {
            int i = Random.Range(0, answers.Count);
            button.GetComponentInChildren<TextMeshProUGUI>().text = answers[i];
            button.onClick.RemoveAllListeners();
            if(answers[i] == currentQuiz.trueResponse)
            {
                button.onClick.AddListener(correct);
            }
            else
            {
                button.onClick.AddListener(wrong);
            }
            answers.RemoveAt(i);
        }
    }

    public void wrong()
    {
        Debug.Log("Wrong");
        wrongAudio.Play();
        robotAnimator.Play("SBAGLIATA");
    }

    public void correct()
    {
        Debug.Log("Correct");
        correctAudio.Play();
        robotAnimator.Play("GIUSTA");
        if (correctResponse == (minForPad-1))
        {
            correctResponse = 0;
            //showQuiz();
            switch (obstaclesRequested)
            {
                case 111:
                    {
                        GameManager.gateUnlocked = true;
                        break;
                    }
                case 112:
                    {
                        GameManager.robotUnlocked = true;
                        break;
                    }
                case 113:
                    {
                        GameManager.bridgeUnlocked = true;
                        break;
                    }
                default:
                    Debug.Log("No obstacles");break;
            }
            SceneManager.LoadScene(4);
        }
        else
        {
            correctResponse++;
            showQuiz();
        }
        
        
    }
}
