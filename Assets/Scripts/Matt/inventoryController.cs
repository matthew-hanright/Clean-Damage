using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour
{
    private PlayerController player;

    public Text metal;
    public Text plastic;
    public Text rubber;
    public Text electronics;
    public Text glass;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        metal.text = player.materials[0] + "";
        plastic.text = player.materials[1] + "";
        rubber.text = player.materials[2] + "";
        electronics.text = player.materials[3] + "";
        glass.text = player.materials[4] + "";
    }
}
