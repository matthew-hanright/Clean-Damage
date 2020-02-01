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

    public bool electricityRepaired = false;

    private void Update()
    {
        // If electricity is repaired...
        if (electricityRepaired == true)
        {
            // ...and the player is not here...
            if (playerHere == false)
            {
                // ...turn off the lights
                if (my_Light.color.a < 1f)
                    TurnOffLights();
            } // if
              // Otherwise, we want the lights all the way up,
              // because we have electricity!
            else if (my_Light.color.a > 0f)
                TurnOnLights();
        } // if
        // If electricity is not repaired...
        else
        {
            // ...and the player is not here...
            if (playerHere == false)
            {
                // ...turn off the lights again
                if (my_Light.color.a < 1f)
                    TurnOffLights();
            } // if
            // If the player is in the room with no electricity...
            else
            {
                // ...we only want the lights adjusted a little
                if (my_Light.color.a > 0.5f)
                    BrightenLighting();
            } // else
        } // else
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

    private void TurnOffLights()
    {
        var tempColor = my_Light.color;
        tempColor.a += 0.1f;
        my_Light.color = tempColor;
    } // DimLighting

    private void TurnOnLights()
    {
        var tempColor = my_Light.color;
        tempColor.a -= 0.1f;
        my_Light.color = tempColor;
    } // TurnOnLights

    private void BrightenLighting()
    {
        var tempColor = my_Light.color;
        tempColor.a -= 0.1f;
        my_Light.color = tempColor;
    } // BrightenLighting
} // LightController