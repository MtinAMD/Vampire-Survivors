using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int maxHP = 1000;
    [SerializeField] private int currentHP;
    [SerializeField] private HPbar hpbar;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject weapons;
    private bool isDead = false;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;

    public float hpRegenerationRate = 5f;
    public float hpRegenerationTimer;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
        currentHP = maxHP;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        hpbar.setState(currentHP, maxHP);
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;
        if (hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) 
            return;
        currentHP -= damage;
        if (currentHP <= 0)
        {
            // GAME OVER
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            isDead = true;
        }
        hpbar.setState(currentHP, maxHP);
    }

    public void Heal(int amount)
    {
        if (currentHP <= 0)
            return;
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;
        hpbar.setState(currentHP,maxHP);
    }
}
