using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour
{
    public Button thisButton;
    public GameObject controlsUI;

    private void Start()
    {
        // ...add an onClick listener to the button
        thisButton.onClick.AddListener(toggleControls);
    } // Start

    public void toggleControls()
    {
        if (controlsUI.active == true)
        {
            controlsUI.SetActive(false);
        } // if
        else
            controlsUI.SetActive(true);
    } // toggleControls
} // ControlsButton
