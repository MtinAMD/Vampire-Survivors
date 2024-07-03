using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour , IDamagable
{
    private Transform target_destination;
    private GameObject targetGameObject;
    private PlayerCharacter targetCharacter;
    [SerializeField] private int hp = 10;
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed;
    // add experience to player when enemy is defeated
    [SerializeField] private int experience_reward = 200;
    
    private Rigidbody2D rgdbd2d;
    public GameObject Blood;
    
    private TextMeshProUGUI score;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        score = FindAnyObjectByType<Score>().GetComponent<TextMeshProUGUI>();
    }

    public void setTarget(GameObject target)
    {
        targetGameObject = target;
        target_destination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (target_destination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<PlayerCharacter>();
        }
        targetCharacter.TakeDamage(damage);
    }
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            
            Destroy(gameObject);
            GetComponent<Drop_on_Destroy>().DropItem();
            GameObject blood = Instantiate(Blood, transform.position, quaternion.identity);
            score.GetComponent<Score>().IncreaseScore();
        }
    }
}

