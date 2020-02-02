using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenController : MonoBehaviour
{
    // OxygenController should be attached to the rooms. If the player
    // collides with the room, check if the room's oxygen is repaired.
    // If the oxygen is not repaired, start suffocating the player.

    // This will store the oxygen from PlayerController
    public int player_Oxygen = PlayerController.playerOxygen;

    // This will determine if the room has been repaired and can be manipulated
    // outside of this script
    public bool oxygenRepaired;

    // If a gameObject collides with the fog of war...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (oxygenRepaired == false)
        {
            // ...check if it's the player...
            if (other.gameObject.name == "Player")
            {
                // Stop breathing if the player is...
                CancelInvoke("Breathe");
                // ...and start murdering the player
                InvokeRepeating("Suffocate", 1.0f, 1.0f);
            } // if
        } // if
    } // OnCollisionEnter

    void Suffocate()
    {
        if (player_Oxygen > 0)
        {
            player_Oxygen -= 1;
            Debug.Log("Player has " + player_Oxygen + " oxygen left.");
            PlayerController.playerOxygen = player_Oxygen;
        } // if
    } // Subtract

    // When an object leaves the fog...
    void OnTriggerExit2D(Collider2D other)
    {
        // ...check if it's the player...
        if (other.gameObject.name == "Player")
        {
            // ...and help him out by letting him breathe
            CancelInvoke("Suffocate");
            InvokeRepeating("Breathe", 1.0f, 0.5f);
        } // if
    } // OnTriggerExist

    void Breathe()
    {
        // If the player has room in his lungs...
        if(player_Oxygen < 100)
        {
            // ...breathe
            player_Oxygen += 1;
            PlayerController.playerOxygen = player_Oxygen;
        } // if
        // Otherwise...
        else
            // ...stop breathing
            CancelInvoke("Breathe");
        Debug.Log("Player has " + player_Oxygen + " oxygen left.");
    } // Breathe

} // OxygenController