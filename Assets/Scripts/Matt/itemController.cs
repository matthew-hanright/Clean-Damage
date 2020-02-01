using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    [Header("0: metal, 1: plastic, 2: rubber, 3: electronics, 4: glass")]
    public int type;
    public float collectionLength;
    public int amount;

    public Slider progressBar;
    private Slider pb;

    private float collectionBeginTime;
    private Canvas canvas;
    private bool beingCollected = false;
    private bool collidingWithCollect = false;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (Input.GetButton("Interact") && collidingWithCollect && !beingCollected)
        {
            beingCollected = true;
            collectionBeginTime = Time.time;
            pb = Instantiate(progressBar);
            pb.transform.SetParent(canvas.transform);
            pb.transform.position = transform.position;
        }

        if (Input.GetButtonUp("Interact"))
        {
            beingCollected = false;
            if (pb != null)
            {
                Destroy(pb.gameObject);
            }
        }

        if(beingCollected)
        {
            pb.value = (Time.time - collectionBeginTime) / collectionLength;
            if (Time.time > collectionBeginTime + collectionLength)
            {
                FindObjectOfType<PlayerController>().materials[type] += amount;
                Destroy(this.gameObject);
                Destroy(pb.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collect")
        {
            collidingWithCollect = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "collect")
        {
            beingCollected = false;
            collidingWithCollect = false;
            if (pb != null)
            {
                Destroy(pb.gameObject);
            }
        }
    }
}
