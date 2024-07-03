using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUpObject : MonoBehaviour, IpickupObject
{
    [SerializeField] private int healAmount;
    public void OnPickUp(PlayerCharacter character)
    {
        character.Heal(healAmount);
    }
}
