using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IpickupObject
{
    [SerializeField] private int XPamount;
    
    public void OnPickUp(PlayerCharacter character)
    {
        character.level.AddExperience(XPamount);
    }
}
