
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public TMP_Text display;

    private void Start()
    {
        display = GetComponent<TMP_Text>();
    }

    public void UpdateHealthCounter(int currentHealth)
    {
        display.text = "Health: " + currentHealth;
    }
}
