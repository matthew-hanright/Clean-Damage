using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text[] materials;
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        for(int i = 0; i < materials.Length; i++)
        {
            materials[i].text = player.materials[i] + "";
        }
    }
}
