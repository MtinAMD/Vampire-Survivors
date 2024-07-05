using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscoreText;
    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highscoreText.text = "High Score : " + PlayerPrefs.GetInt("highScore");
        }
        else
            highscoreText.text = "High Score : 0";
    }
}
