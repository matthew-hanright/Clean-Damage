using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        //transform.position = player.transform.position;
    }

    void Update()
    { 
        GetComponent<Rigidbody2D>().velocity = player.GetComponent<Rigidbody2D>().velocity;
    }
}
