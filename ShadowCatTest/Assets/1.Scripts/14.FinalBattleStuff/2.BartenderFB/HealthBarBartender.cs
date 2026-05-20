using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBartender : MonoBehaviour
{
    [SerializeField] private Image[] healthBar;
    private int faseCount = 1;

    public bool FirstFaseEnded { get; set; }
    public bool SecondFaseEnded { get; set; }
    public bool ThirdFaseEnded { get; set; }

    public bool IsBartenderDead { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (faseCount == 1)
            {
                healthBar[0].fillAmount -= 0.35f;

                if (healthBar[0].fillAmount <= 0)
                {
                    healthBar[0].fillAmount = 0;
                    FirstFaseEnded = true;
                    faseCount = 2;
                }
            }
            else if (faseCount == 2)
            {
                healthBar[1].fillAmount -= 0.25f;

                if (healthBar[1].fillAmount <= 0)
                {
                    healthBar[1].fillAmount = 0;
                    SecondFaseEnded = true;
                    faseCount = 3;
                }
            }
            else if (faseCount == 3)
            {
                healthBar[2].fillAmount -= 0.15f;

                if (healthBar[2].fillAmount <= 0)
                {
                    healthBar[2].fillAmount = 0;
                    ThirdFaseEnded = true;
                    IsBartenderDead = true;
                    faseCount = 4;
                }
            }
        }
    }
}
