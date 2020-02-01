using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicDisplayText : MonoBehaviour
{
    public GameObject textBox;
    public Text text;
    public SpriteRenderer portrait;

    public bool hasControl = false;
    public GameObject originator;

    private dialogueArray diagArray;
    private string[] textToDisplay;
    private int currentText = 0;
    private char[] currentLine;
    private int currentChar = 0;

    private float textSpeed = 0.005f;

    public void displayText(GameObject selfReference, dialogueArray textString)
    {
        textSpeed = 0.1f;
        originator = selfReference;
        diagArray = textString;
        textToDisplay = textString.line;
        textBox.SetActive(true);
        text.text = "";
        currentLine = textString.line[currentText].ToCharArray();
        currentChar = 0;
        if(textString.sprite[currentText] != null)
        {
            portrait.sprite = textString.sprite[currentText];
        }
        StartCoroutine(printLine());
    }

    public void displayText(GameObject selfReference, dialogueArray textString, int startAt)
    {
        textSpeed = 0.1f;
        diagArray = textString;
        originator = selfReference;
        currentText = startAt;
        textToDisplay = textString.line;
        textBox.SetActive(true);
        text.text = "";
        currentLine = textString.line[currentText].ToCharArray();
        currentChar = 0;
        if (textString.sprite[currentText] != null)
        {
            portrait.sprite = textString.sprite[currentText];
        }
        StartCoroutine(printLine());
    }

    public void displayText(GameObject selfReference, dialogueArray textString, int startAt, float textSpeedInSeconds)
    {
        textSpeed = textSpeedInSeconds;
        originator = selfReference;
        diagArray = textString;
        currentText = startAt;
        textToDisplay = textString.line;
        textBox.SetActive(true);
        text.text = "";
        currentLine = textString.line[currentText].ToCharArray();
        currentChar = 0;
        if (textString.sprite[currentText] != null)
        {
            portrait.sprite = textString.sprite[currentText];
        }
        StartCoroutine(printLine());
    }

    IEnumerator printLine()
    {
        if (currentChar < currentLine.Length)
        {
            text.text += currentLine[currentChar];
            currentChar++;
            yield return new WaitForSeconds(textSpeed);
            StartCoroutine(printLine());
        }
    }

    private void progressText()
    {
        if (currentText < textToDisplay.Length)
        {
            currentChar = 0;
            text.text = "";
            currentLine = textToDisplay[currentText].ToCharArray();
            if (diagArray.sprite[currentText] != null)
            {
                portrait.sprite = diagArray.sprite[currentText];
            }
            StartCoroutine(printLine());
        }
        else
        {
            endText();
        }
    }

    private void endText()
    {
        hasControl = false;
        currentText = 0;
        currentChar = 0;
        textBox.SetActive(false);
        originator.GetComponent<npcController>().afterDialogueAction();
    }

    private void Update()
    {
        if(hasControl && Input.GetButtonDown("Interact"))
        {
            if (text.text != textToDisplay[currentText])
            {
                text.text = textToDisplay[currentText];
                currentChar = currentLine.Length;
            }
            else
            {
                currentText++;
                progressText();
            }
        }
    }

}
