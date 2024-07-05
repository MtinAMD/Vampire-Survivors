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
    private static bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public static void setQuitting(bool b)
    {
        isQuitting = b;
    }

    public void OnDestroy()
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
