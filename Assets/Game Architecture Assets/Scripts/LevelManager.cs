using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isFinalLevel;

    public UnityEvent onLevelStart, onLevelEnd;

    public void StartLevel()
    {
        onLevelStart?.Invoke();
    }

    public void EndLevel()
    {
        onLevelEnd?.Invoke();
    }
}
