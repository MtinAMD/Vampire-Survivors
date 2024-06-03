using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        GetComponent<PlayerMove>().enabled = false;
        gameOverPanel.SetActive(true);
    }
}
