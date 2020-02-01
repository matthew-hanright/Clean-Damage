using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    public bool broken = true;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player has to have the right material to fix the door
        //The material will then be used and the door will always be fixed
        if (collision.gameObject.tag == "interact" && broken)
        {
            if (FindObjectOfType<PlayerController>().materials[0] >= 1)
            {
                if (FindObjectOfType<PlayerController>().materials[1] >= 1)
                {
                    Debug.Log("Fixed");
                    FindObjectOfType<DoorOpen>().broken = false;
                    FindObjectOfType<DoorOpen>().animator.SetBool("fixed", true);
                    FindObjectOfType<PlayerController>().materials[0]--;
                    FindObjectOfType<PlayerController>().materials[1]--;
                }
                else
                {
                    Debug.Log("Not enough materials");
                }
            }
            else
            {
                Debug.Log("Not enough materials");
            }
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
