using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{

    // Choose a text object to display the timer
    public Text TimerText;

    // The timer will default to 60 seconds, but you can choose a time
    // in seconds in the editor
    public float countdownTime = 60;

    // The player must be referenced so that we can get to the LoseScript
    // which will trigger the loss animation
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // If the countdown hasn't timed out yet...
        if (countdownTime > 1)
        {
            // ...subtract from the countdown
            countdownTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(countdownTime / 60F);
            int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);

            // Format the textual representation to look pretty and update the
            // Text object
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            TimerText.text = niceTime;
        } // if
        // Otherwise, if the countdown has timed out, kill the player!
        else
            player.GetComponent<LoseScript>().TimeOut();
    } // Update
} // TimerController