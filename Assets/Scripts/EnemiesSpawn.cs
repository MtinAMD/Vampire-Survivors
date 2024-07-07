using System;
using System.Collections;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemy2;

    [SerializeField] private Vector2 spawnPos;
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject enemyAnimation;
    [SerializeField] private GameObject enemyAnimation2;
    
    private GameObject player;
    private float timer;


    private void Start()
    {
        player = GameManager.instance.PlayerTransform.gameObject;
        reset();
    }


    private int level;
    private void Update()
    {
        level = player.GetComponent<Level>().level;
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            if (level >= 5)
            {
                SpawnEnemy();
            }
            timer = spawnTimer;
        }
    }

    private void puk(UnityEngine.Vector3 x)
    {
        GameObject newEnemy2 = Instantiate(enemy2);
        newEnemy2.transform.position = x;
        newEnemy2.GetComponent<Enemy>().setTarget(player);
        newEnemy2.transform.parent = transform;
        
        GameObject spriteObject2 = Instantiate(enemyAnimation2);
        spriteObject2.transform.parent = newEnemy2.transform;
        spriteObject2.transform.localPosition = UnityEngine.Vector3.zero;
    }

    private void bat(UnityEngine.Vector3 x)
    {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = x;
        newEnemy.GetComponent<Enemy>().setTarget(player);
        newEnemy.transform.parent = transform;
        
        
        GameObject spriteObject = Instantiate(enemyAnimation);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = UnityEngine.Vector3.zero;

    }

    private int count_level = 4;
    private void SpawnEnemy()
    {
        UnityEngine.Vector3 position = GenerateRandomPosition();
        position += player.transform.position;
        
        if (level == 1)
        {
            bat(position);
        }
        else
        {
            if (level == 2)
            {
                puk(position);
            }
            else
            {
                if (level == 3)
                {
                   bat(position);
                   puk(position);
                }
                else
                {
                    if (count_level == level)
                    {
                        count_level++;
                        upgrade();
                        // player.GetComponentInParent<PlayerCharacter>().set_currentHP(15);
                    }
                    bat(position);
                    puk(position);
                }
            }
        }
    }

    private void reset()
    {
        enemy.GetComponent<Enemy>().Damage = 1;
        enemy.GetComponent<Enemy>().Speed = 2;
        enemy.GetComponent<Enemy>().Hp = 2;
        enemy.GetComponent<Enemy>().ExperienceReward = 75;
        enemy2.GetComponent<Enemy>().ExperienceReward = 100;
        enemy2.GetComponent<Enemy>().Hp = 2;
        enemy2.GetComponent<Enemy>().Speed = 1;
        enemy2.GetComponent<Enemy>().Damage = 2;
        player.GetComponentInParent<PlayerCharacter>().set_currentHP(1000);
    }

    private void upgrade()
    {
        double chance = Random.value;
        
        if (chance <= 0.25)
        {
        enemy.GetComponent<Enemy>().Damage += 1;
        }
        else
        { 
            if (0.25 < chance  &&  chance <= 0.5)       
            {
                enemy.GetComponent<Enemy>().Speed += 1;
            }
            else
            { 
                if (0.5 < chance  &&  chance <= 0.75) 
                { 
                    enemy2.GetComponent<Enemy>().Damage += 1; 
                }
                else
                {
                enemy2.GetComponent<Enemy>().Hp += 1;
                }
            }
        }
        enemy.GetComponent<Enemy>().ExperienceReward += 50;
        enemy2.GetComponent<Enemy>().ExperienceReward += 30;
    }
    
    private UnityEngine.Vector3 GenerateRandomPosition()
    {
        UnityEngine.Vector3 position = new UnityEngine.Vector3();

        float random = Random.value > 0.5f ? -1f : 1f;
        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnPos.x, spawnPos.x);
            position.y = spawnPos.y * random;
        }
        else
        {
            position.y = Random.Range(-spawnPos.y, spawnPos.y);
            position.x = spawnPos.x * random;
        }
        position.z = 0f;

        return position;
    }
}
