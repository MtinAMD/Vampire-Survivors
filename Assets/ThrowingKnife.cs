using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    [SerializeField] private float timeToAttack;
    private float timer;
    [SerializeField] private GameObject knifePrefab;
    private PlayerMove PlayerMove;

    private void Awake()
    {
        PlayerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        GameObject thrownKnife = Instantiate(knifePrefab);
        thrownKnife.transform.position = transform.position;
        thrownKnife.GetComponent<ThrowingKnifeProjectable>().SetDirection(PlayerMove.LastHorizontalVector, 0f);
    }

    }
