using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntryDoorCloseTrigger : MonoBehaviour
{
    [SerializeField] private Door door;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.OpenDoor(false);
            door.LockDoor();
        }
    }
}
