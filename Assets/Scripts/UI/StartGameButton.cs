using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartGameButton : MonoBehaviour
{
    public void StartGamePlay(string scene)
    {
        
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(scene,LoadSceneMode.Additive);
    }
}
