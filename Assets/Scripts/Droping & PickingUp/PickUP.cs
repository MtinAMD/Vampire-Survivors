using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PickUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCharacter character = other.GetComponent<PlayerCharacter>();
        if (character != null)
        {
            //character.Heal(heal_amount);
            GetComponent<IpickupObject>().OnPickUp(character);
            Destroy(gameObject);
        }
    }
}
