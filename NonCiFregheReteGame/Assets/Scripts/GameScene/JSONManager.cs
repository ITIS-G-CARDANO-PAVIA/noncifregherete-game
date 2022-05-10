<<<<<<< HEAD
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
        ListQuiz listQuizz = new ListQuiz();
        listQuizz = JsonUtility.FromJson<ListQuiz>(quizz.text);
        return listQuizz;
    }
}
=======
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
>>>>>>> bace051aca7fd07d66aaab69e5e969127dd492c3
