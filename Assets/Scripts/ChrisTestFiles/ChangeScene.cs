using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public Button thisButton;
    public string goTo;

    private void Start()
    {
        thisButton.onClick.AddListener(nextScene);
    } // Start

    public void nextScene()
    {
        SceneManager.LoadScene(goTo);
    } // nextScene
} // ChangeScene
