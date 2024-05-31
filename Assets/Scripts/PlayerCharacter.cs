using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int maxHP = 1000;
    [SerializeField] private int currentHP;
    [SerializeField] private HPbar hpbar;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        hpbar.setState(currentHP, maxHP);
        if (currentHP <= 0)
        {
            Debug.Log("GAME OVER");
            // animation of dying !!
        }
    }

    public void Heal(int amount)
    {
        if (currentHP <= 0)
            return;
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
