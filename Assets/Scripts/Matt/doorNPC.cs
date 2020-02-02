using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorNPC : npcController
{
    private float interactEndTime;
    private float interactWaitTime = 0.1f;

    private void Start()
    {
        
    }

    public override void afterDialogueAction()
    {
       
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
