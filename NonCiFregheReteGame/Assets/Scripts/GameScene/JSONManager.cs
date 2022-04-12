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
        public string title;
        public string[] paragraphs;
    }

    [Serializable]
    public class Quiz
    {
        public string toAsk;
        public string trueResponse;
        public string[] falseResponse;
    }

    [Serializable]
    public class ListDialoghi
    {
        public Dialogo[] dialogo;
    }

    [Serializable]
    public class ListQuiz
    {
        public Quiz[] quiz;
    }

    public ListDialoghi readDialogs(TextAsset dialoghi)
    {
        ListDialoghi listDialoghi = new ListDialoghi();
        listDialoghi = JsonUtility.FromJson<ListDialoghi>(dialoghi.text);
        return listDialoghi;
    }


    public ListQuiz readQuizz(TextAsset quizz)
    {
        ListQuiz listQuiz = new ListQuiz();
        listQuiz = JsonUtility.FromJson<ListQuiz>(quizz.text);
        return listQuiz;
    }

        /* How-To
        ListDialoghi piero = readDialogs();
        Debug.Log(piero.dialogo[0].paragraphs[0]);
        */
}
