using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    public bool broken = true;
    public int metal = 1;
    public int rubber = 1;


    

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
                    Debug.Log("Fixed");
                    broken = false;
                    animator.SetBool("fixed", true);
                    //Debug.Log(FindObjectOfType<DoorOpen>().animator.GetBool("fixed"));
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
