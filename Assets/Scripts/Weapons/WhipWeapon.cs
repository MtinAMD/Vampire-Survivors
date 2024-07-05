using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WhipWeapon : WeaponBase
{
    //[SerializeField] private float time_to_attack = 1f;
    
    //[SerializeField] private int weap_damage = 1;
    [SerializeField] private GameObject leftweapobj;
    [SerializeField] private GameObject rightweapobj;
    private PlayerMove playerMove;
    [SerializeField] private Vector2 weap_attack_size = new Vector2(2.76f, 1.7f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    public override void Attack()
    {
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
            IDamagable temp = colliders[i].GetComponent<IDamagable>();
            if (temp != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                temp.TakeDamage(weaponStats.damage);
            }
        }
    }
    
}
