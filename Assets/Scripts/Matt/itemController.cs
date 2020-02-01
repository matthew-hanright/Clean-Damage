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

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if(Input.GetButtonUp("Interact"))
        {
            beingCollected = false;
            Destroy(pb.gameObject);
        }

        if(beingCollected)
        {
            pb.value = collectionLength / (Time.time - collectionBeginTime);
            if (Time.time > collectionBeginTime + collectionLength)
            {
                FindObjectOfType<PlayerController>().materials[type] += amount;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "interact")
        {
            beingCollected = true;
            collectionBeginTime = Time.time;
            pb = Instantiate(progressBar);
            pb.transform.parent = canvas.transform;
            pb.transform.position = transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("HERE");
    }
}
