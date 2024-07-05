using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDispose : MonoBehaviour
{
    private Transform playerTransform;
    float maxDistance = 25f;
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerTransform = GameManager.instance.PlayerTransform;
    }
}
