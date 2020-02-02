using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{

    public Text TimerText;
    public float countdownTime = 60;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (countdownTime > 1)
        {
            countdownTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(countdownTime / 60F);
            int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            TimerText.text = niceTime;
        } // if
        else
            player.GetComponent<LoseScript>().TimeOut();
    } // Update
} // TimerController