using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private GameObject currentButton;
    public HandController leftHand;
    public HandController rightHand;
    public TemporaryDisabler blockerL;
    public TemporaryDisabler blockerR; 

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Button"))
        {
            currentButton = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button") && currentButton == other.gameObject)
        {
            currentButton = null;
        }
    }

    void Update()
    {
        if (currentButton != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Button Pressed: " + currentButton.name);

            // Play the button animation
            Animator buttonAnimator = currentButton.GetComponent<Animator>();
            if (buttonAnimator != null)
            {
                buttonAnimator.SetTrigger("Press");
            }

            if (currentButton.name == "Button1")
            {
                leftHand.ActivateRotation();
                blockerL.DisableTemporarily();
            }
            if (currentButton.name == "Button2")
            {
                rightHand.ActivateRotation();
                blockerR.DisableTemporarily();
            }
        }
    }
}
