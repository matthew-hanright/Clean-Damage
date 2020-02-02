using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorController : MonoBehaviour
{
    public int[] materialsToRepair = { 0, 2, 0, 3, 2 };

    public string messageToRepair;
    public string messageWhenRepaired;
    public Sprite portrait;

    public GameObject repairPrompt;

    private dialogueArray dialogueToRepair;
    private dialogueArray dialogueWhenRepaired;

    private PlayerController player;

    public bool isRepaired = false;

    private void Start()
    {
        messageToRepair += " metal: 2, rubber: 2, glass: 3.";

        player = FindObjectOfType<PlayerController>();

        dialogueToRepair = new dialogueArray();
        dialogueToRepair.line = new string[] { messageToRepair };
        dialogueToRepair.sprite = new Sprite[] { portrait };

        dialogueWhenRepaired = new dialogueArray();
        dialogueWhenRepaired.line = new string[] { messageWhenRepaired };
        dialogueWhenRepaired.sprite = new Sprite[] { portrait };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "interact")
        {
            if(!isRepaired)
            {
                player.hasControl = false;
                player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
                FindObjectOfType<BasicDisplayText>().hasControl = true;
                FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogueToRepair);
            }
        }
    }

    public void repair()
    {
        isRepaired = true;
        for(int i = 0; i < player.materials.Length; i++)
        {
            player.materials[i] -= materialsToRepair[i];
        }
        FogController[] roomFog = FindObjectsOfType<FogController>();
        foreach (FogController fog in roomFog)
        {
            fog.electricityRepaired = true;
        }
        repairPrompt.SetActive(false);
        FindObjectOfType<BasicDisplayText>().hasControl = true;
        FindObjectOfType<BasicDisplayText>().displayText(gameObject, dialogueWhenRepaired);
    }

    public void cancel()
    {
        repairPrompt.SetActive(false);
        player.hasControl = true;
    }
}
