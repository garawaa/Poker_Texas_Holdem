using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsClick : MonoBehaviour
{
    public GameObject optionsPanel;

    public void ToggleButton()
    {
        if (optionsPanel.activeInHierarchy)
        {
            optionsPanel.SetActive(false);
        }
        else
            optionsPanel.SetActive(true);
    }
}
