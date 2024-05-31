using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] private Vector2Int playerTilePosition;
    [SerializeField] private Vector2Int playerPositionOnTile;
    [SerializeField] private float tileSize = 20f;
    private GameObject[,] tiles;

    [SerializeField] private int tileHorizontalCount;
    [SerializeField] private int tileVerticalCount;

    [SerializeField] private int fieldOfVisionHeight = 3;
    [SerializeField] private int fieldOfVisionWidth = 3;

    private void Awake()
    {
        tiles = new GameObject[3, 3];
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;
            
            playerPositionOnTile.x = CalculatePositionOnAxis(playerPositionOnTile.x, true);
            playerPositionOnTile.y = CalculatePositionOnAxis(playerPositionOnTile.y, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int x = -(fieldOfVisionWidth/2); x <= fieldOfVisionWidth/2; x++)
        {
            for (int y = -(fieldOfVisionHeight/2); y <= fieldOfVisionHeight/2; y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + y, false);
                GameObject tile = tiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(playerTilePosition.x + x, playerTilePosition.y + y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % tileHorizontalCount;
            }
            else
            {
                currentValue++;
                currentValue = tileHorizontalCount - 1 + currentValue % tileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % tileVerticalCount;
            }
            else
            {
                currentValue++;
                currentValue = tileVerticalCount -1 + currentValue % tileVerticalCount;
            }
        }

        return (int)currentValue;
    }

    public void Add(GameObject tile, Vector2Int tilePosition)
    {
        tiles[tilePosition.x, tilePosition.y] = tile;
    }
}
