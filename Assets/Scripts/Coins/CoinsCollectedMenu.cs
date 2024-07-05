using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCollectedMenu : MonoBehaviour
{
    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (PlayerPrefs.HasKey("CoinsCollected"))
        {
            GetComponent<TextMeshProUGUI>().text = "Coins Collected : " + PlayerPrefs.GetInt("CoinsCollected");
        }
        else
            GetComponent<TextMeshProUGUI>().text = "Coins Collected : 0";
    }
}
