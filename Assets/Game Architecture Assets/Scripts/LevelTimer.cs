using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float totalTime = 30.0f;
    private float currentTime;
    public UnityEvent OnTimerEnd;

    public void StartTimer()
    {
        currentTime = totalTime;
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTime--;
        }
        OnTimerEnd?.Invoke();
    }
}
