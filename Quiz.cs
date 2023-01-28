using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI QuestionText;

    [SerializeField] List<QuestionSO> QuestionsList= new List<QuestionSO>();
    QuestionSO CurrentQuestion;

    [Header("Answers")]

    [SerializeField] GameObject[] AnswerButtons;
    int CorrectAnswerIndex;
    [SerializeField] Sprite BaseAnswerSprite;
    [SerializeField] Sprite CorrectAnswerSprite;

    bool HasAnsweredEarly= true;

    [Header("Timer")]
    [SerializeField] Image TimerImage;
    Timer Timer;

    [Header("Scoring")]

    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeping ScoreKeeping;

    [Header("ProgressBar")]

    [SerializeField] Slider ProgressBar;

    public bool IsComplete;
    
    void Start()
    {
        Timer= FindObjectOfType<Timer>();
        ScoreKeeping = FindObjectOfType<ScoreKeeping>();
        scoreText.text = scoreText.text="Puan : 0 %";
        ProgressBar.minValue=0;
        ProgressBar.maxValue=QuestionsList.Count;
        ProgressBar.value = 0;
        
    }
    void Update()
    {
        TimerFiller();
        
    }

    void TimerFiller()
    {
        TimerImage.fillAmount = Timer.FillFraction;
        if (Timer.LoadNextQuestion)
        {
            HasAnsweredEarly=false;
            GetNextQuestion();
            Timer.LoadNextQuestion = false;
        }
        else if(!HasAnsweredEarly && !Timer.bShowAnswerState)
        {
            SetButtonState(false);
            DisplayAnswer(-1);

        }
    }

    void DisplayQuestion()
    {
        QuestionText.text = CurrentQuestion.GetQuestion();
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            TextMeshProUGUI ButtonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();

            ButtonText.text = CurrentQuestion.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        HasAnsweredEarly=true;
        DisplayAnswer(index);
        SetButtonState(false);
        Timer.CancelTimer();
        scoreText.text="Puan : " + ScoreKeeping.CalculateScore() + "%";


        if(ProgressBar.value== ProgressBar.maxValue)
        {
            Invoke("GameEnded",5); 
        }
    }

    void GameEnded()
    {
        IsComplete=true;
    }
    void DisplayAnswer(int index)
    {
        Image ButtonImage;
        if (index == CurrentQuestion.GetCorrectAnswerIndex())
        {
            QuestionText.text = "Tebrikler cevap doğru.";
            ButtonImage = AnswerButtons[index].GetComponent<Image>();
            ButtonImage.sprite = CorrectAnswerSprite;
            ScoreKeeping.IncrementCorrectAnswers();
        }
        else
        {
            string CorrectAnswerText = CurrentQuestion.GetAnswer(CurrentQuestion.GetCorrectAnswerIndex());
            QuestionText.text = "Yanlış! \n " + CorrectAnswerText;
            ButtonImage = AnswerButtons[CurrentQuestion.GetCorrectAnswerIndex()].GetComponent<Image>();
            ButtonImage.sprite = CorrectAnswerSprite;
        }
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            Button Button = AnswerButtons[i].GetComponent<Button>();

            Button.interactable= state;

        }
    }

    void GetNextQuestion()
    {
        if(QuestionsList.Count>0)
        {
        SetButtonState(true);
        SetDefaultButtonSprites();
        GetRandomQuestion();
        DisplayQuestion();
        ScoreKeeping.IncrementQuestionSeen();
        ProgressBar.value++;
        }
        
    }

    void GetRandomQuestion()
    {
        int index= Random.Range(0,QuestionsList.Count);
        CurrentQuestion= QuestionsList[index];

        if(QuestionsList.Contains(CurrentQuestion))
        {
            QuestionsList.Remove(CurrentQuestion);
        }
        
    }


    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            Image ButtonImage = AnswerButtons[i].GetComponent<Image>();
            ButtonImage.sprite = BaseAnswerSprite;
        }
    }

    public int GetQuestionListCount()
    {
        return QuestionsList.Count;
    }

}

