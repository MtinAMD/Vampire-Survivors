using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private float TimeToLeave = 2f;
    private float time_to_leave = 2f;

    private void OnEnable()
    {
        time_to_leave = TimeToLeave;
    }

    private void Update()
    {
        time_to_leave -= Time.deltaTime;
        if (time_to_leave < 0)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
} 
