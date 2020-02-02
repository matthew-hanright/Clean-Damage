using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapController : MonoBehaviour
{
    public GameObject repairPrompt;
    public Button electricity;
    public Button oxygen;

    private PlayerController player;

    public GameObject activeRoom;

    public bool isPrompting = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void prompt()
    {
        isPrompting = true;
        repairPrompt.SetActive(true);
        if (player.materials[3] < 1 || 
            player.materials[4] < 1 ||
            activeRoom.GetComponent<mapRoom>().room.GetComponent<FogController>().electricityRepaired)
        {
            electricity.interactable = false;
        }
        else
        {
            electricity.interactable = true;
        }

        if (player.materials[1] < 1 || 
            player.materials[2] < 1 ||
            activeRoom.GetComponent<mapRoom>().room.GetComponent<OxygenController>().oxygenRepaired)
        {
            oxygen.interactable = false;
        }
        else
        {
            oxygen.interactable = true;
        }
    }

    public void stopPrompt()
    {
        isPrompting = false;
        activeRoom.GetComponent<SpriteRenderer>().enabled = false;
        repairPrompt.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(isPrompting)
        {
            stopPrompt();
        }
    }

    public void fixElectric()
    {
        activeRoom.GetComponent<mapRoom>().fixRoomElectricity();
        stopPrompt();
        player.materials[3]--;
        player.materials[4]--;
    }

    public void fixOxygen()
    {
        activeRoom.GetComponent<mapRoom>().fixRoomOxygen();
        stopPrompt();
        player.materials[1]--;
        player.materials[2]--;
    }
}
