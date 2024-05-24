using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool isFinalLevel;

    public UnityEvent onLevelStart, onLevelEnd;

    [SerializeField] public List<PressurePadSwitch> switches;
    [SerializeField] public DoorObserver door;

    private void Start()
    {
        onLevelStart.AddListener(RegisterObservers);
    }

    public void StartLevel()
    {
        onLevelStart?.Invoke();
    }

    public void EndLevel()
    {
        onLevelEnd?.Invoke();
        if (isFinalLevel)
        {
            GameManager.instance.ChangeState(GameManager.GameState.GameEnd, this);
        }
        else
        {
            GameManager.instance.ChangeState(GameManager.GameState.LevelEnd, this);
        }
    }

    private void RegisterObservers()
    {
        foreach (var sw in switches)
        {
            sw.RegisterObserver(door);
        }
    }
}
