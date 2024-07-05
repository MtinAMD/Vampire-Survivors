using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    public void reset()
    {
        PlayerPrefs.SetInt("highScore", 0);
        highScoreText.GetComponent<HighScoreMenu>().UpdateText();
    }
}
