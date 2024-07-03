using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePosition;
    [SerializeField] private List<SpawnObject> spawnObjects;
    
    private void Start()
    {
        GetComponentInParent<World>().Add(gameObject, tilePosition);
        //transform.position = new Vector3(-10, -10, 0);
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }
}
