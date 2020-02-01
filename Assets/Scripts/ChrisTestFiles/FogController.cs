using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogController : MonoBehaviour
{
    // Get the renderer whose alpha value we'll be changing
    public SpriteRenderer my_Light;

    // Boolean to determine if the player is in the room
    public bool playerHere = false;

    private void Update()
    {
        // If the player is not here, turn the lights off
        if (playerHere == false)
        {
            if (my_Light.color.a < 0.9f)
                DimLighting();
        } // if
        // Otherwise, we want the lights on
        else
            if (my_Light.color.a > 0f)
                BrightenLighting();
    } // Update

    // When something enters the room...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ...check if it's the player...
        if (collision.gameObject.name == "Player")
            playerHere = true;
    } // OnTriggerEnter2D

    // When something leaves the room...
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ...see if it's the player...
        if (collision.gameObject.name == "Player")
            playerHere = false;
    } // OnTriggerExit2D

    private void DimLighting()
    {
        var tempColor = my_Light.color;
        tempColor.a += 0.1f;
        my_Light.color = tempColor;
    } // DimLighting

    private void BrightenLighting()
    {
        var tempColor = my_Light.color;
        tempColor.a -= 0.1f;
        my_Light.color = tempColor;
    } // BrightenLighting
} // LightController