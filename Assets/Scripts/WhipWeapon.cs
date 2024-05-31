using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private float time_to_attack = 4f;
    private float timer;

    [SerializeField] private GameObject leftwhipobj;
    [SerializeField] private GameObject rightwhipobj;

    private PlayerMove playerMove;
    [SerializeField] private Vector2 whip_attack_size = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

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

        if (playerMove.LastHorizontalVector > 0)
        {
            rightwhipobj.SetActive(true);
        }
        else
        {
            leftwhipobj.SetActive(true);
        }
        
    }
    
    
}
