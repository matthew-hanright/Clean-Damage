using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollowUV : MonoBehaviour
{

    public Vector3 pz;
    public Vector3 StartPos;

    public int parralax;

    // Use this for initialization
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
        //Debug.Log("Mouse Position: " + pz);

        transform.position = new Vector3(StartPos.x + (pz.x * parralax), StartPos.y + (pz.y * parralax), 0);
        //move based on the starting position and its modified value.
    }

}