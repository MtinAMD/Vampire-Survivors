using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;

    public void openPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void closePanel()
    {
        optionsPanel.SetActive(false);
    }
}
