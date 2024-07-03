using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinsAcquired;
    [SerializeField] private TextMeshProUGUI coinsText;

    public void Add(int count)
    {
        coinsAcquired += count;
        coinsText.text = "Coins : " + coinsAcquired.ToString();
    }
}
