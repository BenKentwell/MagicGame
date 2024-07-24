using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public CharacterController characterController;

    public AudioManager audioMang;

    public Weapon currentWeapon;

    public int health = 100;

    private HealthDisplay healthDisplay;

    private string sceneName;

    void Start()
    {
        audioMang = FindObjectOfType<AudioManager>();

        if (!characterController)
            characterController = GetComponent<CharacterController>();

        healthDisplay = FindObjectOfType<HealthDisplay>();

        healthDisplay.UpdateHealthCounter(health);

        sceneName = SceneManager.GetActiveScene().name;
    }

    public void DamagePlayer(int _amountToDamage)
    {
        audioMang.PlayDamagePlayer();
        health -= _amountToDamage;
        healthDisplay.UpdateHealthCounter(health);
    }

    private void Update()
    {
        if(health <= 0)
        {
            Time.timeScale = 0.1f;
            StartCoroutine(Die_CR());
        }
    }

    private IEnumerator Die_CR()
    {
        audioMang.PlayKillPlayer();
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        
    }
}

