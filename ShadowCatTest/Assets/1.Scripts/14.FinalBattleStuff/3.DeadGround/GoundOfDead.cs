using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundOfDead : MonoBehaviour
{
    [SerializeField] private PlayerDamage playerDamage;
    [SerializeField] private GameManagerScript gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDamage.IsPlayerDead = true;
            gameManager.playerIsDead = true;
        }
    }
}
