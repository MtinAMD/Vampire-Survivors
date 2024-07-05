using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // this Script has been given to playerCharacter object
    public int coinsAcquired;
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            coinsAcquired = PlayerPrefs.GetInt("CoinsCollected");
        }
        UpdateText();
    }

    public void Add(int count)
    {
        coinsAcquired += count;
        coinsText.text = "Coins : " + coinsAcquired.ToString();
    }

    private void OnDestroy()
    {
        SaveCoinsCount();
    }

    private void SaveCoinsCount()
    {
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            if (coinsAcquired > PlayerPrefs.GetInt("CoinsCollected"))
                PlayerPrefs.SetInt("CoinsCollected", coinsAcquired);
        }
        else
        {
            PlayerPrefs.SetInt("CoinsCollected", coinsAcquired);
        }
    }

    public void UpdateText()
    {
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            coinsText.text = "Coins : " + PlayerPrefs.GetInt("CoinsCollected");
        }
        else
            coinsText.text = "Coins : 0";
    }
}
