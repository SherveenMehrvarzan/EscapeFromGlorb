using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public bool displayOnce;
    private bool hasDisplayed = false;

    public string message;
    public string instructionMessage;
    public string disablePrompt;

    public GameObject msgBox;
    public Text messageLabel;
    public Text instructionLabel;

    private bool active = false;

    public GameObject next;

    private bool activatedThisFrame = false;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown(disablePrompt)) && active && !activatedThisFrame) {
            msgBox.SetActive(false);
            if (next != null) next.SendMessage("Activate");
            active = false;
        }
        if (activatedThisFrame) activatedThisFrame = false;
    }

    public void Activate()
    {
        active = true;
        activatedThisFrame = true;
        if (displayOnce) hasDisplayed = true;
        messageLabel.text = message;
        instructionLabel.text = instructionMessage;

        if (!msgBox.activeInHierarchy)
        {
            msgBox.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            if (other.gameObject.GetComponent<Character>().getActivePlayerState() && !hasDisplayed)
            {
                active = true;
                if (displayOnce) hasDisplayed = true;
                messageLabel.text = message;
                instructionLabel.text = instructionMessage;

                if (!msgBox.activeInHierarchy)
                {
                    msgBox.SetActive(true);
                }
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            if (other.gameObject.GetComponent<Character>().getActivePlayerState())
            {
                active = false;
                if (msgBox.activeInHierarchy)
                {
                    msgBox.SetActive(false);
                }
            }
        }
    }
}
