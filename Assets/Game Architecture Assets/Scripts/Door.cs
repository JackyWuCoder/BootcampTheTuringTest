using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    private bool isLocked = true;
    private float timer = 0;
    private const float waitTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked && other.gameObject.CompareTag("Player"))
        {
            //Reset timer
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isLocked)
            return; 
        if (!other.CompareTag("Player")) 
            return;  
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = waitTime;
            //Open the door
            //doorAnimator.SetBool("Door", true);
            OpenDoor(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Close the door
        //Change the colour of the door
        //doorAnimator.SetBool("Door", false)
        OpenDoor(false);
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }

    public void LockDoor()
    {
        isLocked = true;
    }

    public void OpenDoor(bool doorState)
    {
        if (isLocked)
        {
            doorAnimator.SetBool("Door", doorState);
        }
    }
}