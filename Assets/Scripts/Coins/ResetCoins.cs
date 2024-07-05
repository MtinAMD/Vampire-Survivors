using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsCollectedText;

    public void reset()
    {
        PlayerPrefs.SetInt("CoinsCollected", 0);
        coinsCollectedText.GetComponent<CoinsCollectedMenu>().UpdateText();
    }
}
