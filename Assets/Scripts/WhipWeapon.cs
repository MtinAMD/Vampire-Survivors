using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    private float time_to_attack = 4f;
    private float timer;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
           Attack(); 
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        timer = time_to_attack;
    }
}
