using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRoom : MonoBehaviour
{
    public GameObject room;

    public Color hover = new Color(10, 100, 30, 255);
    public Color click = new Color(30, 255, 50, 255);

    private mapController map;

    private void Start()
    {
        map = FindObjectOfType<mapController>();
    }

    private void OnMouseEnter()
    {
        if (!map.isPrompting)
        {
            GetComponent<SpriteRenderer>().color = hover;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (!map.isPrompting)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (!map.isPrompting)
        { 
            GetComponent<SpriteRenderer>().color = click;
            map.activeRoom = this.gameObject;
            map.prompt();
        }
        else
        {
            map.stopPrompt();
        }
    }

    public void fixRoomElectricity()
    {
        room.GetComponent<FogController>().electricityRepaired = true;
    }

    public void fixRoomOxygen()
    {
        room.GetComponent<OxygenController>().oxygenRepaired = true;
    }
}
