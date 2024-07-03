using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void RestartGamePlay()
    {
        Drop_on_Destroy.setQuitting(true);
        SceneManager.LoadScene("GamePlayScene");
    }
}
