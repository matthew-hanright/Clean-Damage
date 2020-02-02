using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorNPC : npcController
{
    public float interactEndTime;
    public float interactWaitTime = 0.1f;

    private void Start()
    {
        
    }

    public override void afterDialogueAction()
    {
        interactEndTime = Time.time;
        endDialogue();
    }

    new private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    new private void endDialogue()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.hasControl = true;
        interactEndTime = Time.time;
    }
}
