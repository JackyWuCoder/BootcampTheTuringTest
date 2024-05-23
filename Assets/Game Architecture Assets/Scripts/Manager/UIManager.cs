using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health playerHealth;

    public TMP_Text txtHealth;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
    }

    private void OnEnable()
    {
        playerHealth.OnHealthUpdated += OnHealthUpdate;
        playerHealth.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthUpdated -= OnHealthUpdate;
    }

    void OnHealthUpdate(float health)
    {
        txtHealth.text = "Health : " + Mathf.Floor(health).ToString();
    }

    void OnDeath()
    {
        gameOverText.SetActive(true);
    }
}
