using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class configMenu : MonoBehaviour
{

    [SerializeField] private Text fakeBtn;
    [SerializeField] private Text gamingBtn;
    [SerializeField] private Text odioBtn;
    [SerializeField] private Text restoBtn;

    private void Start()
    {
        if (!GameManager.enabledArgs[0])
        {
            fakeBtn.text = "Fake Disabled";
        }
        else
        {
            fakeBtn.text = "Fake Enabled";
        }
        if (!GameManager.enabledArgs[1])
        {
            gamingBtn.text = "Gaming Disabled";
        }
        else
        {
            gamingBtn.text = "Gaming Enabled";
        }
        if (!GameManager.enabledArgs[2])
        {
            odioBtn.text = "Hate Disabled";
        }
        else
        {
            odioBtn.text = "Hate Enabled";
        }
        if (!GameManager.enabledArgs[3])
        {
            restoBtn.text = "Resto Disabled";
        }
        else
        {
            restoBtn.text = "Resto Enabled";
        }
    }

    public void edFakeNews()
    {
        
        if (GameManager.enabledArgs[0])
        {
            GameManager.enabledArgs[0] = false;
            fakeBtn.text = "Fake Disabled";
        }
        else
        {
            GameManager.enabledArgs[0] = true;
            fakeBtn.text = "Fake Enabled";
        }
    }
    public void edGaming()
    {
        
        if (GameManager.enabledArgs[1])
        {
            GameManager.enabledArgs[1] = false;
            gamingBtn.text = "Gaming Disabled";
        }
        else
        {
            GameManager.enabledArgs[1] = true;
            gamingBtn.text = "Gaming Enabled";
        }
    }
    public void edOdio()
    {
        if (GameManager.enabledArgs[2])
        {
            GameManager.enabledArgs[2] = false;
            odioBtn.text = "Hate Disabled";
        }
        else
        {
            GameManager.enabledArgs[2] = true;
            odioBtn.text = "Hate Enabled";
        }
    }
    public void edResto()
    {
        if (GameManager.enabledArgs[3])
        {
            GameManager.enabledArgs[3] = false;
            restoBtn.text = "Resto Disabled";
        }
        else
        {
            GameManager.enabledArgs[3] = true;
            restoBtn.text = "Resto Enabled";
        }
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
