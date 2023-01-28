using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public bool bShowAnswerState=false;
    public float FillFraction;

    public bool LoadNextQuestion;
    [SerializeField] float TimeToCompleteQuestion=30;
    [SerializeField] float TimeToShowCorrectAnswer = 5;

    float TimerValue;
    void Update()
    {
        UpdateTime();
        
    }
    public void CancelTimer()
    {
        TimerValue =0;
    }

    void UpdateTime()
    {
        TimerValue-= Time.deltaTime;
        if(bShowAnswerState)
        {
            if(TimerValue>0)
            {
                FillFraction= TimerValue/TimeToCompleteQuestion;
            }
            else
            {
                bShowAnswerState=false;
                TimerValue=TimeToShowCorrectAnswer;

            }
        }
        else
        {
            if(TimerValue>0)
            {
                FillFraction= TimerValue/TimeToShowCorrectAnswer;
            }
            else
            {
                bShowAnswerState=true;
                LoadNextQuestion= true;
                TimerValue=TimeToCompleteQuestion;
            } 
            
            
        }
    }
}
