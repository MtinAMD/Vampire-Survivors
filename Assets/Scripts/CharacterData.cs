using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public String Name;
    public GameObject SpritePrefab;
    public WeaponData StartingData;
}
