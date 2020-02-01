using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class multipleItemController : MonoBehaviour
{
    [Header("0: metal, 1: plastic, 2: rubber, 3: electronics, 4: glass")]
    public int type1;
    public int type2;
    public float collectionLength;
    public int amount1;
    public int amount2;

    public Slider progressBar;
    private Slider pb;

    private float collectionBeginTime;
    private Canvas canvas;
    private bool beingCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "interact")
        {
            collectionBeginTime = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "interact")
        {
            if(Time.time > collectionBeginTime + collectionLength)
            {
                FindObjectOfType<PlayerController>().materials[type1] += amount1;
                FindObjectOfType<PlayerController>().materials[type2] += amount2;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "interact")
        {
            beingCollected = false;
            Destroy(pb);
        }
    }
}
