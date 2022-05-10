<<<<<<< HEAD
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
=======
using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private TypeWriterEffect typeWriterEffect;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        // yield return new WaitForSeconds(3);

        foreach (string dialogue in dialogueObject.GetDialogue())
        {
            yield return typeWriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));  // mettere il touch
        }

        CloseDialogueBox();
    } 

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
>>>>>>> bace051aca7fd07d66aaab69e5e969127dd492c3
