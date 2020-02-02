using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{

    public GameObject suffocatedUI;
    public GameObject timeOutUI;
    public GameObject player;
    public GameObject timer;

    public bool timeOutCondition = false;
    public bool suffocationCondition = false;

    public void Suffocated()
    {
        suffocationCondition = true;
        if (timeOutCondition == false)
        {
            suffocatedUI.SetActive(true);
            player.SetActive(false);
            timer.SetActive(false);
        } // if
    } // Suffocated

    public void TimeOut()
    {
        timeOutCondition = true;
        if (suffocationCondition == false)
        {
            timeOutUI.SetActive(true);
            player.SetActive(false);
            timer.SetActive(false);
        } // if
    } // TimeOut
} // DeathScript
