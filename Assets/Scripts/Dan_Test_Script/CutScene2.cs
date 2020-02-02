using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene2 : MonoBehaviour
{
    public Animator animator;
    public bool stop = false;
    public SpriteRenderer player;
    // Start is called before the first frame update
    void Start()
    {
        player.enabled = false;
        Dialouge();

    }

    private void Dialouge()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("twoDone") && stop)
        {
            stop = false;
            Done();
        }
    }

    private void Done()
    {
        player.enabled = true;
    }
}
