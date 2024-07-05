using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    private void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void IncreaseScore()
    {
        score += 1;
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    private void SaveScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
                PlayerPrefs.SetInt("highScore", score);
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
