using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public AudioSource openSound;
    public AudioSource repairSound;
    public Animator animator;
    public bool broken = true;
    public int metal = 1;
    public int rubber = 1;

    public Sprite portrait;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player has to have the right material to fix the door
        //The material will then be used and the door will always be fixed
        if (collision.gameObject.tag == "interact" && broken)
        {
            if (FindObjectOfType<PlayerController>().materials[0] >= metal)
            {
                if (FindObjectOfType<PlayerController>().materials[2] >= rubber)
                {
                    //Debug.Log("Fixed");
                    repairSound.Play();
                    broken = false;
                    animator.SetBool("fixed", true);
                    //Debug.Log(FindObjectOfType<DoorOpen>().animator.GetBool("fixed"));
                    FindObjectOfType<PlayerController>().materials[0]--;
                    FindObjectOfType<PlayerController>().materials[1]--;
                }
                else
                {
                    if (Time.time > FindObjectOfType<doorNPC>().interactEndTime + FindObjectOfType<doorNPC>().interactWaitTime)
                    {
                        dialogueArray dialogueNotEnough = new dialogueArray();
                        dialogueNotEnough.line = new string[] { "You need metal: " + metal + ", and rubber: " + rubber + " to repair a door." };
                        dialogueNotEnough.sprite = new Sprite[] { portrait };
                        PlayerController player = FindObjectOfType<PlayerController>();
                        player.hasControl = false;
                        player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                        FindObjectOfType<BasicDisplayText>().hasControl = true;
                        FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogueNotEnough);
                    }
                }
            }
            else
            {
                if (Time.time > FindObjectOfType<doorNPC>().interactEndTime + FindObjectOfType<doorNPC>().interactWaitTime)
                {
                    dialogueArray dialogueNotEnough = new dialogueArray();
                    dialogueNotEnough.line = new string[] { "You need metal: " + metal + ", and rubber: " + rubber + " to repair a door." };
                    dialogueNotEnough.sprite = new Sprite[] { portrait };
                    PlayerController player = FindObjectOfType<PlayerController>();
                    player.hasControl = false;
                    player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                    FindObjectOfType<BasicDisplayText>().hasControl = true;
                    FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogueNotEnough);
                }
            }
        }
        //This block controls the doors movement
        else if (collision.gameObject.tag == "interact" && !animator.GetBool("open") && !broken)
        {
            openSound.Play();
            animator.SetBool("open", true);
        }
        else if(collision.gameObject.tag == "interact" && animator.GetBool("open") && !broken)
        {
            openSound.Play();
            animator.SetBool("open", false);
        }
    }
}
