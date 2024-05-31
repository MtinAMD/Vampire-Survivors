using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    private GameObject targetGameObject;

    [SerializeField] private Transform target_destination;

    [SerializeField] private float speed;
    private Rigidbody2D rgdbd2d;
    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = target_destination.gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (target_destination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

//     private void OnCollisionStay2D(Collision2D other)
//     {
//         if (Collision.gameObject == targetGameObject)
//         {
//             Attack();
//         }
//     }
//
//     private void Attack()
//     {
//         Debug.Log("Attacing the player");
//     }
 }

