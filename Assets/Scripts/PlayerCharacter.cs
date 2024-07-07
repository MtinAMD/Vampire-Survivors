using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int maxHP = 1000;
    [SerializeField] private int currentHP;
    [SerializeField] private HPbar hpbar;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject weapons;
    private bool isDead = false;

    public void set_currentHP(int deposit)
    {
        currentHP += deposit;
    }
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
    
    private void InitAnim(GameObject sprit)
    {
        GameObject animGameObject =  Instantiate(sprit, transform);
        GetComponent<Animate>().SetAnimate(animGameObject);
    }

    private void Loadd(CharacterData selectt)
    {
        InitAnim(selectt.SpritePrefab);
    }
    private void Start()
    {
        Loadd(selecttt);
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

     private CharacterData selecttt;

    public void stss(CharacterData o)
    {
        selecttt = o;
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
