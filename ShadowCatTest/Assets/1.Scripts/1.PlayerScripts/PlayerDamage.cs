using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameManagerScript gameManager; 
    [SerializeField] private GameObject damagePanel;

    private SwitchLite playerScript;
    private int maxHealth = 5;
    private float currentHealth;
    private bool canDamage = true;

    [HideInInspector]
    public bool IsPlayerDead = false;

    private void Awake()
    {
        playerScript = FindFirstObjectByType<SwitchLite>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void DealDamage()
    {
        if (canDamage)
        {
            if (StateGameController.playerCanDie)
            {
                currentHealth--;
                healthBar.SetHealth(currentHealth);

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    gameManager.playerIsDead = true;
                    IsPlayerDead = true;
                }

                canDamage = false;
                StartCoroutine(WaitForDamage());
            }
        }
    }

    public void DealDamageQuantity(float damage)
    {
        if (playerScript.isInCinematic) return;

        if (StateGameController.playerCanDie)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameManager.playerIsDead = true;
                IsPlayerDead = true;
            }

            StartCoroutine(PanelDeDanio());
        }
    }

    public void GainHealth(float health)
    {
        if (IsPlayerDead) return;

        currentHealth += health;
        healthBar.SetHealth(currentHealth);

        if (currentHealth > 5)
        {
            currentHealth = 5;
        }
    }

    public void PuedeRecibirDaño(bool valor)
    {
        if (!valor) canDamage = false;
        else canDamage = true;
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

    IEnumerator PanelDeDanio()
    {
        if (!gameManager.playerIsDead)
        {
            damagePanel.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            damagePanel.SetActive(false);
        }
    }
}
