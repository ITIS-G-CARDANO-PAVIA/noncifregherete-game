using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private AudioSource audioSource;

    private TypeWriterEffect typeWriterEffect;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        JSONManager jm = new JSONManager();
        JSONManager.ListDialoghi dialoghi = jm.readDialogs(textAsset);
        audioSource.Play();
        ShowDialogue(dialoghi.dialogo);
    }
    
    public void ShowDialogue(JSONManager.Dialogo[] dialogue)
    {
        dialogueBox.SetActive(true);
        print(dialogue.Length);
        StartCoroutine(StepThroughDialogue(dialogue));
    }

    private IEnumerator StepThroughDialogue(JSONManager.Dialogo[] dialogue)
    {
        for (int i = GameManager.dialogueToShow[0]; i < GameManager.dialogueToShow[1]; i++)
        {
            SetStatusDialogueBox(true);
            string[] dialogueArray = dialogue[i].paragraphs;

            foreach (string text in dialogueArray)
            {
                yield return typeWriterEffect.Run(text, textLabel);
                //yield return new WaitUntil(() => (Input.touchCount > 0));
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0));
                audioSource.Play();
            }
            SetStatusDialogueBox(false);
            
        }
        GameManager.isQuizEnabled = true;
    } 

    private void SetStatusDialogueBox(bool status)
    {
        dialogueBox.SetActive(status);
        textLabel.text = string.Empty;
    }
}
