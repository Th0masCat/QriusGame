using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Quiz[] questions;
    public List<Quiz> unansweredQuestions;

    public Quiz currentQuestion;

    [SerializeField]
    private Text questionText;

    public int questionCount = 0;

    BattleSystem battleSystem;
    private void Start()
    {
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Quiz>();
        }

    }

    public void SetCurrentQuestion()
    {
        currentQuestion = unansweredQuestions[questionCount];
        questionText.text = currentQuestion.question;
        questionCount++;
    }
}
