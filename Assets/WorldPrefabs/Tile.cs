using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePosition;

    private void Start()
    {
        GetComponentInParent<World>().Add(gameObject, tilePosition);
    }
}
