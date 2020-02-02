using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generatorNPC : npcController
{
    public generatorController engine;

    public Button yes;

    private float interactEndTime;
    private float interactWaitTime = 0.1f;

    private void Start()
    {
        engine = FindObjectOfType<generatorController>();
    }

    public override void afterDialogueAction()
    {
        if (!engine.isRepaired)
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            FindObjectOfType<generatorController>().repairPrompt.SetActive(true);
            yes.interactable = true;
            for(int i = 0; i < engine.materialsToRepair.Length; i++)
            {
                if(player.materials[i] < engine.materialsToRepair[i])
                {
                    yes.interactable = false;
                }
            }
        }
        else
        {
            endDialogue();
        }
    }

    new private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    new private void endDialogue()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.hasControl = true;
        interactEndTime = Time.time;
    }
}
