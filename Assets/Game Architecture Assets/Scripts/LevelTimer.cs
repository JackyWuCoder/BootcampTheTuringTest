using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float totalTime = 30.0f;
    [SerializeField] private TextMeshProUGUI levelTimerText;
    private float currentTime;
    public UnityEvent OnTimerEnd;

    public void StartTimer()
    {
        currentTime = totalTime;
        levelTimerText.text = currentTime.ToString();
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTime--;
            levelTimerText.text = currentTime.ToString();
        }
        OnTimerEnd?.Invoke();
    }
}
