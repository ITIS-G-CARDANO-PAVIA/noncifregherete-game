using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    int playerPosition = 1;

    [SerializeField]
    private TMP_Text textd;
    // Start is called before the first frame update
    void Start()
    {
        textd.text = "Pronto per giocare? Premi A";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            switch (playerPosition)
            {
                case 1: textd.text = "Provola 1";break;
                case 2: textd.text = "Provola 2";break;
                default: playerPosition = 0;break;
            }
            playerPosition++;
        }   
    }
}
