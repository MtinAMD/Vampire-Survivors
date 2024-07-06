using System;
using System.Collections;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnPos;
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject enemyAnimation;
    private GameObject player;
    private float timer;


    private void Start()
    {
        player = GameManager.instance.PlayerTransform.gameObject;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        UnityEngine.Vector3 position = GenerateRandomPosition();
        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().setTarget(player);
        newEnemy.transform.parent = transform;


        GameObject spriteObject = Instantiate(enemyAnimation);
        spriteObject.transform.parent = newEnemy.transform;
        spriteObject.transform.localPosition = UnityEngine.Vector3.zero;
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
