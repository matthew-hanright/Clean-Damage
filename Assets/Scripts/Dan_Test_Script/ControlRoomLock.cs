using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoomLock : MonoBehaviour
{
    public AudioSource openSound;
    public AudioSource repairSound;
    public Animator animator;
    public bool broken = true;
    public int metal = 1;
    public int rubber = 1;

    private lifeSupportController lifeSupport;
    private engineController engine;
    private generatorController generator;

    public Sprite portrait;

    private void Start()
    {
        lifeSupport = FindObjectOfType<lifeSupportController>();
        engine = FindObjectOfType<engineController>();
        generator = FindObjectOfType<generatorController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player has to have the right material to fix the door
        //The material will then be used and the door will always be fixed
        if (collision.gameObject.tag == "interact" && broken)
        {
            if (lifeSupport.isRepaired && engine.isRepaired && generator.isRepaired)
            {
                repairSound.Play();
                broken = false;
                animator.SetBool("fixed", true);
            }
            else
            {
                dialogueArray dialogueNotEnough = new dialogueArray();
                dialogueNotEnough.line = new string[] { "You need to repair the 3 core systems to disengage the lockdown." };
                dialogueNotEnough.sprite = new Sprite[] { portrait };
                PlayerController player = FindObjectOfType<PlayerController>();
                player.hasControl = false;
                player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                FindObjectOfType<BasicDisplayText>().hasControl = true;
                FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogueNotEnough);
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
