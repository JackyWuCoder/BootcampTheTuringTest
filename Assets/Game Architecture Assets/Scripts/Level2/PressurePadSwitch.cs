using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePadSwitch : MonoBehaviour
{
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private float checkRadius;

    //public UnityEvent OnCubePlaced;
    //public UnityEvent OnCubeRemoved;

    // List of observers that needs to be notified
    private List<ISwitchObserver> observers = new List<ISwitchObserver>();
    private bool isActivated = false;

    public bool IsActivated()
    {
        return isActivated;
    }

    public void RegisterObserver(ISwitchObserver observer)
    {
        observers.Add(observer);
    }

    // When switch is activated notify the observers
    public void ActivateSwitch()
    {
        isActivated = true;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnSwitchActivated();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if cube is closer to the middle
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayerMask);

        // Debug.Log(colliders.Length);

        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.gameObject.name);
            if (collision.gameObject.CompareTag("PickCube"))
            {
                Debug.Log("Hi");
                if (GetComponent<Renderer>().material.color ==
                    collider.gameObject.GetComponentInChildren<Renderer>().material.color)
                {
                    ActivateSwitch();
                    GetComponent<Renderer>().material.color = Color.green;
                }
                break;
            }
        }
    }
}
