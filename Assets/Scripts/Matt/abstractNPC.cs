using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class abstractNPC : MonoBehaviour
{
    public dialogueArray[] dialogue;
    public int currentDialogue;

    private PlayerController player;

    private float interactEndTime;
    private float interactWaitTime = 0.1f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void afterDialogueAction()
    {

    }

    public void endDialogue()
    {
        
    }
}
