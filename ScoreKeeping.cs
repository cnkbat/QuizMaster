using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeping : MonoBehaviour
{
    
    
    int CorrectAnswers = 0;
    int QuestionSeen= 0;

    public int GetCorrectAnswers()
    {
        return CorrectAnswers;
    }
    public void IncrementCorrectAnswers()
    {
        CorrectAnswers++;
    }

    public int GetQuestionSeen()
    {
        return QuestionSeen;
    }
    public void IncrementQuestionSeen()
    {
        QuestionSeen++;
    }

    //Calculate'i questionseen mantıksız baya questionliste getter yazıp ordan çekip soruların tamamına bölmek daha mantıklı.
    public int CalculateScore()
    {
        float Score = CorrectAnswers/(float) QuestionSeen * 100;
        return Mathf.RoundToInt(Score);
    }
}
