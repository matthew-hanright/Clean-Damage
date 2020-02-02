using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float positiveAcceleration = 2;
    public float negativeAcceleration = 3;
    public float maxSpeed = 6;

    public static int playerOxygen = 100;
    public Text oxygenText;
    public GameObject pausedUI;

    [Header("0: metal, 1: plastic, 2: rubber, 3: electronics, 4: glass")]
    public int[] materials = { 0, 0, 0, 0, 0 };

    public bool hasControl = true;

    public GameObject interactBox;
    public GameObject inventoryUI;

    private void Update()
    {
        string myOxygen = playerOxygen.ToString();
        oxygenText.text = myOxygen;

        // Check if the player has suffocated...
        if (playerOxygen == 0)
        {
            // ...and end the game if this is the case
            GetComponent<LoseScript>().Suffocated();
        } // if

        if (hasControl)
        {
            if (Input.GetButtonDown("Interact"))
            {
                interactBox.layer = 0;
            }
            else if (Input.GetButtonUp("Interact"))
            {
                interactBox.layer = 8;
            }
        }
        else
        {
            interactBox.layer = 8;
        }
        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("Escape Pressed");
            if (Time.timeScale > 0)
            {
                Debug.Log("Time Stop");
                Time.timeScale = 0;
                //pausedUI.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                //pausedUI.SetActive(false);
                Debug.Log("Time Start");
                Time.timeScale = 1;
            }
        }
    }

    private void FixedUpdate()
    {
        float newHSpeed = GetComponent<Rigidbody2D>().velocity.x;
        float newVSpeed = GetComponent<Rigidbody2D>().velocity.y;

        //Horizontal Movement
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            newHSpeed += positiveAcceleration * Mathf.Sign(Input.GetAxis("Horizontal"));
            if(newHSpeed > maxSpeed)
            {
                newHSpeed = maxSpeed;
            }
            else if(newHSpeed < -maxSpeed)
            {
                newHSpeed = -maxSpeed;
            }
        }
        else if(newHSpeed != 0)
        {
            if(Mathf.Abs(newHSpeed) > negativeAcceleration)
            {
                newHSpeed = negativeAcceleration * Mathf.Sign(newHSpeed);
            }
            else
            {
                newHSpeed = 0;
            }
        }

        //Vertical Movement
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f) {
            newVSpeed += positiveAcceleration * Mathf.Sign(Input.GetAxis("Vertical"));
            if (newVSpeed > maxSpeed)
            {
                newVSpeed = maxSpeed;
            }
            else if (newVSpeed < -maxSpeed)
            {
                newVSpeed = -maxSpeed;
            }
        }
        else if (newVSpeed != 0)
        {
            if (Mathf.Abs(newVSpeed) > negativeAcceleration)
            {
                newVSpeed = negativeAcceleration * Mathf.Sign(newVSpeed);
            }
            else
            {
                newVSpeed = 0;
            }
        }

        if (hasControl)
        {
            //Apply Movement
            GetComponent<Rigidbody2D>().velocity = new Vector2(newHSpeed, newVSpeed);

            //Face the mouse
            Vector3 truetoCameraPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 faceDirection = Input.mousePosition - truetoCameraPosition;
            float angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
