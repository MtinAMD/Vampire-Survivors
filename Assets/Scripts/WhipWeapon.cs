using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private float time_to_attack = 4f;
    private float timer;
    [SerializeField] private int weap_damage = 1;
    [SerializeField] private GameObject leftweapobj;
    [SerializeField] private GameObject rightweapobj;
    private PlayerMove playerMove;
    [SerializeField] private Vector2 weap_attack_size = new Vector2(1.8f, 1.5f);

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
        timer = time_to_attack;

        if (playerMove.LastHorizontalVector > 0)
        {
            rightweapobj.SetActive(true);
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(rightweapobj.transform.position, weap_attack_size, 0f);
            ApplyDamage(collider2Ds);
        }
        else
        {
            leftweapobj.SetActive(true);
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(leftweapobj.transform.position, weap_attack_size, 0f);
            ApplyDamage(collider2Ds);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Enemy temp = colliders[i].GetComponent<Enemy>();
            if (temp != null)
            {
                //colliders[i].GetComponent<Enemy>().TakeDammage(weap_dammage);
                temp.TakeDammage(weap_damage);
            }
        }
    }
    
}
