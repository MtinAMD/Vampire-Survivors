using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PickUP : MonoBehaviour
{
    [SerializeField] private int heal_amount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCharacter character = other.GetComponent<PlayerCharacter>();
        if (character != null)
        {
            character.Heal(heal_amount);
            Destroy(gameObject);
        }
    }
}
