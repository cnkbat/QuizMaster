using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI FinalScoreText;

    ScoreKeeping ScoreKeeping;
    // Start is called before the first frame update
    void Awake()
    {
        ScoreKeeping = FindObjectOfType<ScoreKeeping>();
        
    }

    public void ShowFinalScore()
    {
        FinalScoreText.text= "Helal aga!\n" + ScoreKeeping.CalculateScore()+ "% puan kazandın.";
    }

}
