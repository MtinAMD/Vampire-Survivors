using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Drop_on_Destroy : MonoBehaviour
{
    [SerializeField] private GameObject dropItemPrefab;
    [SerializeField] [Range(0f, 1f)] private float chance = 1f;
    private Boolean isQuitting = false;

    public void OnApplicationQuit()
    {
        isQuitting = false;
    }

    // this will be called in Enemy.cs after the enemy destroys
    public void DropItem()
    {
        if (isQuitting)
        {
            return;
        }
        if (Random.value < chance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
    }
}
