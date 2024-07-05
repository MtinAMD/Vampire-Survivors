using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : WeaponBase
{
    //[SerializeField] private float timeToAttack = 5f;
    
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private float spread = 0.05f;
    
    private PlayerMove PlayerMove;

    private void Awake()
    {
        PlayerMove = GetComponentInParent<PlayerMove>();
    }

    public override void Attack()
    {

        for (int i = 0; i < weaponStats.numberOfAttack; i++)
        {
            GameObject thrownKnife = Instantiate(knifePrefab);

            Vector3 newKnifeposition = transform.position;
            if (weaponStats.numberOfAttack > 1)
            {
                newKnifeposition.y -= (spread * (weaponStats.numberOfAttack - 1)) / 2;
                newKnifeposition.y += i * spread;
            }
           
            thrownKnife.transform.position = newKnifeposition;
            
     //       thrownKnife.transform.position = transform.position;

            ThrowingKnifeProjectable throwingKnifeProjectable = thrownKnife.GetComponent<ThrowingKnifeProjectable>();
            throwingKnifeProjectable.SetDirection(PlayerMove.LastHorizontalVector, 0f);
        
            //will be useful after upgrading
            throwingKnifeProjectable.damage = weaponStats.damage;
        }
        
    }
}
