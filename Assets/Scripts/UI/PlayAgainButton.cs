using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void RestartGamePlay(string scene)
    {
        Drop_on_Destroy.setQuitting(true);
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
}
