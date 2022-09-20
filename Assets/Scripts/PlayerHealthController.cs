using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public SpriteRenderer[] heartDisplay;
    public Sprite heartFull, heartEmpty;

    public Transform heartHolder;

    public float invincibilityTime, healthFlashTime = .2f;
    private float invincibilityCounter, flashCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter < 0)
            {
                flashCounter = healthFlashTime;

                heartHolder.gameObject.SetActive(!heartHolder.gameObject.activeInHierarchy);
            }

            if(invincibilityCounter <= 0)
            {
                heartHolder.gameObject.SetActive(true);
            }
        }
    }

    public void LateUpdate()
    {
        heartHolder.localScale = transform.localScale;
    }

    public void UpdateHealthDisplay()
    {
        switch(currentHealth)
        {
            case 3: 
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartFull;
                break;

            case 2:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartEmpty;

                break;

            case 1:
                heartDisplay[0].sprite = heartEmpty;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartEmpty;

                break;
                
            case 0:
                heartDisplay[0].sprite = heartEmpty;
                heartDisplay[1].sprite = heartEmpty;
                heartDisplay[2].sprite = heartEmpty;

                break;
        }
    }

    public void DamagePlayer(int damageToTake)
    {
        if(invincibilityCounter <= 0)
        {

            AudioManager.instance.PlaySFX(3);
            currentHealth -= damageToTake;
        
            if(currentHealth < 0)
            {
                
                currentHealth = 0;
            
            }
    

            UpdateHealthDisplay();

            if(currentHealth == 0)
            {
                
                 gameObject.SetActive(false);

                 AudioManager.instance.PlaySFX(2);

                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            
            }

            invincibilityCounter = invincibilityTime;
        }
    }

    public void fillHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();

        flashCounter = 0;
        invincibilityCounter = 0;

        heartHolder.gameObject.SetActive(true);
    }
}
