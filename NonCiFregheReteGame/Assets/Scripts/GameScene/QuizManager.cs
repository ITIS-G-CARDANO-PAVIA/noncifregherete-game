using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TextAsset txtAsset;

    private TypeWriterEffect typeWriterEffect;

    void makeAQuiz()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        JSONManager jsm = new JSONManager();
        JSONManager.ListQuiz listQuiz = jsm.readQuizz(txtAsset);
    }

    public void ShowDialogue(JSONManager.Dialogo[] dialogue)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogue));
    }

    public void trueResponse()
    {
        SceneManager.LoadScene("PadScene", LoadSceneMode.Single);
    }

    private IEnumerator StepThroughDialogue(JSONManager.Dialogo[] dialogue)
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            SetStatusDialogueBox(true);
            string[] dialogueArray = dialogue[i].paragraphs;

            foreach (string text in dialogueArray)
            {
                yield return typeWriterEffect.Run(text, textLabel);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));  // mettere il touch
            }
            SetStatusDialogueBox(false);

            /* Apettare tra la chiusura del Box e l'apertura di un altro Box
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.J));
            */
        }
    }

    private void SetStatusDialogueBox(bool status)
    {
        dialogueBox.SetActive(status);
        textLabel.text = string.Empty;
    }

}
