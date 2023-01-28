using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="QuestionSO",fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(0,5)]
    [SerializeField] string Question = "Enter new question";

    [SerializeField] string[] Answers= new string[4];
    [SerializeField] int CorrectAnswerIndex;

    [SerializeField] QuestionSO[] QuestionList;
    public string GetQuestion()
    {
        return Question;
    }
    public int GetCorrectAnswerIndex()
    {
        return CorrectAnswerIndex;
    }
    public string GetAnswer(int index)
    {
        return Answers[index];
    }
}