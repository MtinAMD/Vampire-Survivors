using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        Drop_on_Destroy.setQuitting(true);
        SceneManager.LoadScene("MainMenu");
    }
}
