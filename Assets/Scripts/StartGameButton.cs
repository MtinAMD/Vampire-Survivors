using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGamePlay()
    {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene("GamePlayScene",LoadSceneMode.Additive);
    }
}
