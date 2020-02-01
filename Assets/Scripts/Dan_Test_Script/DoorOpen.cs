using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    bool broken = true;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player has to have the right material to fix the door
        //The material will then be used and the door will always be fixed
        if (collision.gameObject.tag == "interact" && broken)
        {
            Debug.Log("Fixed");
            broken = false;
        }
        //This block controls the doors movement
        else if (collision.gameObject.tag == "interact" && !animator.GetBool("open") && !broken)
        {
            //Debug.Log("Door is Open");
            animator.SetBool("open", true);
        }
        else if(collision.gameObject.tag == "interact" && animator.GetBool("open") && !broken)
        {
            //Debug.Log("Door is Closed");
            animator.SetBool("open", false);
        }
    }
}
