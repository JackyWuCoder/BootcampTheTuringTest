using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObserver : MonoBehaviour, ISwitchObserver
{
    [SerializeField] private Animator doorAnimator;

    [SerializeField] private List<PressurePadSwitch> switches = new List<PressurePadSwitch>();
    private bool isLocked = true;

    // Checks if all switches are activated and if it is unlock the door
    public void OnSwitchActivated()
    {
        if (AllSwitchesActivated())
        {
            UnlockDoor();
            OpenDoor(true);
        }
    }

    // OnSwitchActivated helper function
    private bool AllSwitchesActivated()
    {
        foreach (var sw in switches)
        {
            Debug.Log("switches.Length: " + switches.Count);
            Debug.Log("AKLL DFQWEJIQWEQWIHJEQWEQW");
            if (!sw.IsActivated())
            {
                return false;
            }
        }
        return true;
    }

    private void UnlockDoor()
    {
        isLocked = false;
    }

    public void OpenDoor(bool doorState)
    {
        if (!isLocked)
        {
            doorAnimator.SetBool("Door", doorState);
        }
    }
}