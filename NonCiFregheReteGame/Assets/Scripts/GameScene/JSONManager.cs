using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONManager: MonoBehaviour
{
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

    public ListDialoghi readDialogs(TextAsset dialoghi)
    {
        ListDialoghi listDialoghi = new ListDialoghi();
        listDialoghi = JsonUtility.FromJson<ListDialoghi>(dialoghi.text);
        return listDialoghi;
    }

        /* How-To
        ListDialoghi piero = readDialogs();
        Debug.Log(piero.dialogo[0].paragraphs[0]);
        */
}
