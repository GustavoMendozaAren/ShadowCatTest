using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 3;
    public float currentHealth;

    public HealthBar healthBar;

    private bool canDamage = true;

    [HideInInspector]
    public bool PlayerDead = false;

    public GameManagerScript gameManager;

    public GameObject damagePanel;

    private void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void DealDamage()
    {
        if (canDamage)
        {

        currentHealth--;
            healthBar.SetHealth(currentHealth);

            if (currentHealth == 0)
            {
                gameManager.playerIsDead = true;
                PlayerDead = true;
            }

            canDamage = false;
            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        if (!gameManager.playerIsDead)
        {
            damagePanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            damagePanel.SetActive(false);
            canDamage = true;
        }
    }
}
