using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz Quiz;

    EndScreen EndScreen;
    void Start()
    {
        Quiz =FindObjectOfType<Quiz>();
        EndScreen=FindObjectOfType<EndScreen>();

        Quiz.gameObject.SetActive(true);
        EndScreen.gameObject.SetActive(false);
    }
    void Update()
    {
        if(Quiz.IsComplete)
        {
            Quiz.gameObject.SetActive(false);
            EndScreen.gameObject.SetActive(true);
            EndScreen.ShowFinalScore();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
