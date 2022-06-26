using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionModel> QnA;
    public GameObject[] Options;
    public int CurrentQuestion;
    public Text QuestionTxt;
    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(CurrentQuestion);
        generateQuestion();
    }

    void generateQuestion(){
        if(QnA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[CurrentQuestion].Question;
            setAnswers();
            QnA.RemoveAt(CurrentQuestion);
        }
        
    }
    void setAnswers()
    {
        for(int i=0; i<Options.Length; i++)
        {
            Options[i].GetComponent<AnswerScript>().IsCorrect = false;
            Options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];

            if(QnA[CurrentQuestion].CorrectAnswerIndex == i + 1)
            {
                Options[i].GetComponent<AnswerScript>().IsCorrect = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
