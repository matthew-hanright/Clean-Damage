using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeSupportNPC : npcController
{
    public lifeSupportController lifeSupport;

    public Button yes;
    public Button no;

    private float interactEndTime;
    private float interactWaitTime = 0.1f;

    private void Start()
    {
        lifeSupport = FindObjectOfType<lifeSupportController>();
    }

    public override void afterDialogueAction()
    {
        if (!lifeSupport.isRepaired)
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            FindObjectOfType<lifeSupportController>().repairPrompt.SetActive(true);
            yes.interactable = true;
            yes.onClick.AddListener(FindObjectOfType<lifeSupportController>().repair);
            no.onClick.AddListener(FindObjectOfType<lifeSupportController>().cancel);
            for (int i = 0; i < lifeSupport.materialsToRepair.Length; i++)
            {
                if(player.materials[i] < lifeSupport.materialsToRepair[i])
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
