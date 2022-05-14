using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager2 : MonoBehaviour
{
    public static bool toReactivate = false;
    public TextAsset quizJSON;
    public TextMeshProUGUI question;
    public Button[] answerButtons = new Button[3];
    public int currentQuizIdx;
    public int correctResponse = 0;
    private JSONManager.Quiz[] quiz;
    private int correctAnswerIdx;

    // Start is called before the first frame update
    void Start()
    {
        this.currentQuizIdx = 0;
        JSONManager json = new JSONManager();
        this.quiz = json.readQuizz(this.quizJSON).quiz;
        this.currentQuizIdx = 0;
        this.showQuiz();
    }

    void showQuiz(int currentIdx)
    {
        this.currentQuizIdx = currentIdx;
        this.showQuiz();
    }

    void showQuiz()
    {
        JSONManager.Quiz currentQuiz = this.quiz[this.currentQuizIdx];
        this.question.text = currentQuiz.toAsk;
        List<string> answers = new List<string>();
        answers.AddRange(currentQuiz.falseResponse);
        answers.Add(currentQuiz.trueResponse);
        foreach(Button button in this.answerButtons)
        {
            int i = Random.Range(0, answers.Count);
            button.GetComponentInChildren<TextMeshProUGUI>().text = answers[i];
            button.onClick.RemoveAllListeners();
            if(answers[i] == currentQuiz.trueResponse)
            {
                correctAnswerIdx = i;
                button.onClick.AddListener(this.correct);
            }
            else
            {
                button.onClick.AddListener(this.wrowg);
            }
            answers.RemoveAt(i);
        }
    }

    public void wrowg()
    {
        Debug.Log("Wrong");
    }

    public void correct()
    {
        Debug.Log("Correct");
        if(correctResponse == 4)
        {
            correctResponse = 0;
            SceneManager.LoadScene(4);
        }
        else
        {
            correctResponse++;
            this.showQuiz(this.currentQuizIdx + 1);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
