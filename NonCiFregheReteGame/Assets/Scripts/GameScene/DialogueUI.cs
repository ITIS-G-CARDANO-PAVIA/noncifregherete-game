using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private AudioSource popAudio0;
    [SerializeField] private AudioSource popAudio1;
    [SerializeField] private AudioSource popAudio2;

    private TypeWriterEffect typeWriterEffect;


    private void playRand()
    {
        int rnd = Random.Range(1, 4);
        Debug.Log(rnd);
        switch (rnd)
        {
            case 1:
                popAudio0.Play();break;
            case 2:
                popAudio1.Play();break;
            case 3:
                popAudio2.Play();break;
            default:
                Debug.Log("Nothing to do"); break;
        }
    }

    private void Start()
    {
        if (!GameManager.isQuizEnabled)
        {
            typeWriterEffect = GetComponent<TypeWriterEffect>();
            JSONManager jm = new JSONManager();
            JSONManager.ListDialoghi dialoghi = jm.readDialogs(textAsset);
            playRand();
            ShowDialogue(dialoghi.dialogo);
        }
    }
    
    public void ShowDialogue(JSONManager.Dialogo[] dialogue)
    {
        dialogueBox.SetActive(true);
        print(dialogue.Length);
        StartCoroutine(StepThroughDialogue(dialogue));
    }

    private IEnumerator StepThroughDialogue(JSONManager.Dialogo[] dialogue)
    {
        if (!GameManager.enabledArgs[0])
        {
            if(GameManager.dialogueToShow[0] == 0)
            {
                if(GameManager.dialogueToShow[1] == 1)
                {
                    SceneManager.LoadScene(4);
                }
            }
        }

        for (int i = GameManager.dialogueToShow[0]; i < GameManager.dialogueToShow[1]; i++)
        {
            SetStatusDialogueBox(true);
            string[] dialogueArray = dialogue[i].paragraphs;

            foreach (string text in dialogueArray)
            {
                yield return typeWriterEffect.Run(text, textLabel);
                //yield return new WaitUntil(() => (Input.touchCount > 0));
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0));
                playRand();
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
