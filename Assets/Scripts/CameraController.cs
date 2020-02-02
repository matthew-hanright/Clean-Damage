using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void Update()
    { 
        GetComponent<Rigidbody2D>().velocity = player.GetComponent<Rigidbody2D>().velocity;
    }
}
