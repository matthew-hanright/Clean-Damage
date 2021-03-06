﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeSupportController : MonoBehaviour
{
    public int[] materialsToRepair = { 0, 2, 0, 3, 2 };

    public string messageToRepair;
    public string messageWhenRepaired;
    public Sprite portrait;

    public GameObject repairPrompt;

    private dialogueArray dialogueToRepair;
    private dialogueArray dialogueWhenRepaired;

    private PlayerController player;

    public bool isRepaired = false;

    private void Start()
    {
        messageToRepair += " plastic: 2, electronics: 3, glass: 2.";

        player = FindObjectOfType<PlayerController>();

        dialogueToRepair = new dialogueArray();
        dialogueToRepair.line = new string[] { messageToRepair };
        dialogueToRepair.sprite = new Sprite[] { portrait };

        dialogueWhenRepaired = new dialogueArray();
        dialogueWhenRepaired.line = new string[] { messageWhenRepaired };
        dialogueWhenRepaired.sprite = new Sprite[] { portrait };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "interact")
        {
            if(!isRepaired)
            {
                player.hasControl = false;
                //player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                FindObjectOfType<BasicDisplayText>().hasControl = true;
                FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogueToRepair);
            }
        }
    }

    public void repair()
    {
        isRepaired = true;
        for(int i = 0; i < player.materials.Length; i++)
        {
            player.materials[i] -= materialsToRepair[i];
        }
        repairPrompt.SetActive(false);
        OxygenController[] roomOxygen = FindObjectsOfType<OxygenController>();
        foreach (OxygenController oxy in roomOxygen) {
            oxy.oxygenRepaired = true;
        }
        FindObjectOfType<BasicDisplayText>().hasControl = true;
        FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogueWhenRepaired);
    }

    public void cancel()
    {
        repairPrompt.SetActive(false);
        player.hasControl = true;
    }
}
