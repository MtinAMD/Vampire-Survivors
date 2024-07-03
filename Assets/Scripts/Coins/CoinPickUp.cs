using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour, IpickupObject
{
    [SerializeField] private int count;
    public void OnPickUp(PlayerCharacter character)
    {
        character.coins.Add(count);
    }
}
