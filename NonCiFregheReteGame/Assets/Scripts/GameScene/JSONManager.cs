using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset textJSON;

    [Serializable]
    public class Dialogo
    {
        public int id;
        public string title;
        public string[] paragraphs;
    }

    [Serializable]
    public class ListDialoghi
    {
        public Dialogo[] dialogo;
    }

    public ListDialoghi listDialoghi = new ListDialoghi();

    void Start()
    {

        listDialoghi = JsonUtility.FromJson<ListDialoghi>(textJSON.text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
