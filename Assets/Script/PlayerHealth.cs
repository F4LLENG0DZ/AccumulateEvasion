using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;

    public int maxHealth = 3;
    int currentHealth;
    public Text CurrentHealth;

    public CameraShake cameraShake;

    public float shakeIntensity = 0.5f;
    public float shakeDuration = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);   
            if (currentHealth < 0)
            {
                CurrentHealth.text = "0";
            }
            else 
            {
                CurrentHealth.text = currentHealth.ToString();
            }
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FindObjectOfType<SoundEffectPlayer>().GameImpactSFX();
        StartCoroutine(cameraShake.Shake(shakeDuration, shakeIntensity));
    }

    void AddHealth(int addhealth) 
    {
        currentHealth += addhealth;
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {   
        if (collision.gameObject.tag == "AddHealthPoint")
        {
            Destroy(collision.gameObject);
            AddHealth(1);
        }
        if (collision.gameObject.tag == "MinusPoint")
        {
            Destroy(collision.gameObject);
            TakeDamage(2);
        }
        if (collision.gameObject.tag == "BigObstacles")
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }
}
