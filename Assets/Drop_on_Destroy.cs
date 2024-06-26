using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Drop_on_Destroy : MonoBehaviour
{
    [SerializeField] private GameObject health_pickup;
    [SerializeField] [Range(0f, 1f)] private float chance = 1f;
    
    private void OnDestroy()
    {
        if (Random.value < chance)
        {
            Transform t = Instantiate(health_pickup).transform;
            t.position = transform.position;
        }

    }
}
