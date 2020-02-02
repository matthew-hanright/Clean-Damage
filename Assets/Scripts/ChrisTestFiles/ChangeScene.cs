using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    // Attach this to the button which will change the scene. Here, we make
    // a reference to the button which will be pressed
    public Button thisButton;

    // This is a reference to the scene which we will go to. Literally just
    // type the name of the preferred scene in the editor.
    public string goTo;

    // When the scene starts...
    private void Start()
    {
        // ...add an onClick listener to the button
        thisButton.onClick.AddListener(nextScene);
    } // Start

    // This is the function called when the button is clicked
    public void nextScene()
    {
        // It uses the Unity SceneManager to move to the desired scene
        Time.timeScale = 1;
        SceneManager.LoadScene(goTo);
    } // nextScene
} // ChangeScene
