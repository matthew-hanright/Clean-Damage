using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene1 : MonoBehaviour
{
    public Animator animator;
    public bool stop = false;
    public SpriteRenderer player;
    // Start is called before the first frame update
    void Start()
    {
        player.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("oneDone") && stop)
        {
            stop = false;
            Done();
        }
    }

    public void Done()
    {
        player.enabled = true;
    }
}
