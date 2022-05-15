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

    private static List<int> alreadyAsked = new List<int>();

    void Start()
    {
        JSONManager json = new JSONManager();
        quiz = json.readQuizz(quizJSON).quiz;
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
    }

    public void correct()
    {
        Debug.Log("Correct");
        if(correctResponse == (minForPad-1))
        {
            correctResponse = 0;
            showQuiz();
            SceneManager.LoadScene(4);
        }
        else
        {
            correctResponse++;
            showQuiz();
        }
        
        
    }
}
