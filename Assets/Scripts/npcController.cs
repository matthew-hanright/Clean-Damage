using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
{
    public dialogueArray[] dialogue;
    public int currentDialogue;

    private PlayerController player;

    private float interactEndTime;
    private float interactWaitTime = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "interact" && Time.time > interactEndTime + interactWaitTime)
        {
            player = FindObjectOfType<PlayerController>();
            player.hasControl = false;
            player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            FindObjectOfType<BasicDisplayText>().hasControl = true;
            FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogue[currentDialogue]);
        }
    }

    public void afterDialogueAction()
    {
        if(currentDialogue < dialogue.Length - 1)
        {
            currentDialogue++;
        }
        endDialogue();
    }

    private void endDialogue()
    {
        player.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        player.hasControl = true;
        interactEndTime = Time.time;
    }

}
