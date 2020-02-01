using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consoleController : MonoBehaviour
{
    public Camera mainCam;
    public Camera mapCam;

    private PlayerController player;

    private bool inRange = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if(inRange && Input.GetButtonDown("Interact"))
        {
            if(mainCam.enabled)
            {
                mainCam.enabled = false;
                mapCam.enabled = true;
                player.hasControl = false;
                player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            }
            else
            {
                mapCam.enabled = false;
                mainCam.enabled = true;
                player.hasControl = true;
                mapRoom[] rooms = FindObjectsOfType<mapRoom>();
                foreach(mapRoom room in rooms)
                {
                    room.GetComponent<SpriteRenderer>().enabled = false;
                }
                FindObjectOfType<mapController>().stopPrompt();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collect")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "collect")
        {
            inRange = false;
        }
    }
}
