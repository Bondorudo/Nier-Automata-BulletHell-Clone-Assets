using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private Renderer rend;
    private GameManager gameManager;
    [SerializeField] private ParticleSystem explosionParticle;

    public float flashLength;
    private float flashCounter;
    private float iFrameCounter;

    private int wallDamage = 1;
    private int startingHealth = 3;
    private int currentHealth;

    private Color storedColor;


    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        currentHealth = startingHealth;
        rend = GetComponentInChildren<Renderer>();
        storedColor = rend.material.GetColor("_Color");
        transform.Find("Health_1").gameObject.SetActive(true);
        transform.Find("Health_2").gameObject.SetActive(true);
        iFrameCounter = flashLength;
    }
    
    void Update()
    {
        // Game over happens if player health is equal to 0
        if (currentHealth <= 0)
        {
            rend.material.SetColor("_Color", storedColor);
            if (!explosionParticle.isPlaying) explosionParticle.Play();
            StartCoroutine(waitForParticles());

        }

        if (currentHealth == 2)
        {
            transform.Find("Health_2").gameObject.SetActive(false);
        }
        if (currentHealth == 1)
        {
            transform.Find("Health_1").gameObject.SetActive(false);
        }
        // Player color is restored to normal
        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
        // Decrease iFrame counter
        if (iFrameCounter > 0)
        {
            iFrameCounter -= Time.deltaTime;
        }
    }

    IEnumerator waitForParticles()
    {
        yield return new WaitForSeconds(0.3f);
        gameManager.GameOver();
    }

    // When player is hurt they lose health and their color turns red
    public void HurtPlayer(int damageAmount)
    {
        // If iFrame counter is less than zero player can take damage again.
        if (flashCounter <= 0)
        {
            currentHealth -= damageAmount;
            rend.material.SetColor("_Color", Color.red);
            flashCounter = flashLength;
            iFrameCounter = flashLength;
        }
        
    }

    // Decrease Health when colliding with damaging walls and enemies
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DamageWall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shield")
        {
            HurtPlayer(wallDamage);
        }
    }
}
