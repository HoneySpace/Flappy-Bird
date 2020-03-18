using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreShow : MonoBehaviour
{
    public static int score = 0;
    public Text current, best;
    int BestScore;
    private void Awake()
    {
        BestScore = PlayerPrefs.GetInt("BestScore",0);
        score = 0;
    }
    void Update()
    {
        this.GetComponent<Text>().text = score.ToString();
    }

    public void SetUpScore()
    {
        current.text = $"Score: {score}";
        if (BestScore < score) BestScore = score;
        best.text = $"Best: {BestScore}";
        PlayerPrefs.SetInt("BestScore", BestScore);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Shown", 0);
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
