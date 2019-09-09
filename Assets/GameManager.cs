using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public int score;
    public int highscore;
    public float foodValue;
    public Text scoreText;
    public Text highscoreText;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("High Score");
        if (highscore != 0)
            highscoreText.text = string.Concat("HIGHSCORE: ", highscore.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            RecordScore();
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    public void RecordScore()
    {
        if (score > highscore)
            PlayerPrefs.SetInt("High Score", score);
    }

    public void UpdateScore()
    {
        scoreText.text = string.Concat("SCORE: ", score.ToString());
        if (score > highscore)
            highscoreText.text = string.Concat("HIGHSCORE: ", highscore.ToString());
    }
}