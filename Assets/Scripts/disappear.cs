using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    private float time_to_disappear = 0.8f;
    private float timer;

    private void OnEnable()
    {
        timer = time_to_disappear;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
