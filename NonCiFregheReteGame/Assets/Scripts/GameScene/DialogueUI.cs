using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TextAsset textAsset;

    private TypeWriterEffect typeWriterEffect;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        JSONManager jm = new JSONManager();
        JSONManager.ListDialoghi dialoghi = jm.readDialogs(textAsset);
        
        ShowDialogue(dialoghi.dialogo);
    }
    
    public void ShowDialogue(JSONManager.Dialogo[] dialogue)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogue));
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
            GameManager.isQuizEnabled = true;
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
