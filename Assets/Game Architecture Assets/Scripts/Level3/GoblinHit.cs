using UnityEngine;
using System;
using UnityEngine.Events;

public class GoblinHit : MonoBehaviour
{
    public UnityEvent OnGoblinHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnGoblinHit?.Invoke();
        }
    }
}
